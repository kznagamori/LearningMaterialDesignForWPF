using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using ControlzEx.Theming;
using MaterialDesignThemes.Wpf;

namespace MaterialMetroAppBase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Dictionary<string, Color> mahAppsAccentsColorMap = new Dictionary<string, Color>
        {
            { "Red", Colors.Red },
            { "Green", Colors.Green },
            { "Blue", Colors.Blue },
            { "Purple", Colors.Purple },
            { "Orange", Colors.Orange },
            { "Lime", Colors.Lime },
            { "Emerald", Color.FromRgb(80, 200, 120) }, // エメラルド
            { "Teal", Colors.Teal },
            { "Cyan", Colors.Cyan },
            { "Cobalt", Color.FromRgb(0, 71, 171) }, // コバルトブルー
            { "Indigo", Colors.Indigo },
            { "Violet", Colors.Violet },
            { "Pink", Colors.Pink },
            { "Magenta", Colors.Magenta },
            { "Crimson", Colors.Crimson },
            { "Amber", Color.FromRgb(255, 191, 0) }, // アンバー
            { "Yellow", Colors.Yellow },
            { "Brown", Colors.Brown },
            { "Olive", Colors.Olive },
            { "Steel", Color.FromRgb(70, 130, 180) }, // スチールブルー
            { "Mauve", Color.FromRgb(224, 176, 255) }, // モーブ
            { "Taupe", Color.FromRgb(72, 60, 50) }, // トープ
            { "Sienna", Colors.Sienna }
        };

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 設定からカラーを取得
            string primaryColorString = MaterialMetroAppBase.Properties.Settings.Default.PrimaryColor;
            string secondaryColorString = MaterialMetroAppBase.Properties.Settings.Default.SecondaryColor;
            SetTheme(primaryColorString, secondaryColorString, false);

        }

        /// <summary>
        /// アプリケーションのテーマを設定します。
        /// </summary>
        /// <param name="primaryColorString">メインカラー</param>
        /// <param name="secondaryColorString">サブカラー</param>
        /// <param name="isDark">ダークテーマを使用するかどうか</param>
        public void SetTheme(string primaryColorString, string secondaryColorString, bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            if (mahAppsAccentsColorMap.TryGetValue(primaryColorString, out Color primaryColor) &&
                mahAppsAccentsColorMap.TryGetValue(secondaryColorString, out Color secondaryColor))
            {
            }
            else
            {
                // 設定に無効なカラーがある場合のデフォルト処理
                primaryColor = Colors.Blue;
                secondaryColor = Colors.Lime;
            }

            theme.SetBaseTheme(isDark ? BaseTheme.Dark : BaseTheme.Light);
            theme.SetPrimaryColor(primaryColor);
            theme.SetSecondaryColor(secondaryColor);
            paletteHelper.SetTheme(theme);


            // 現在のリソースディクショナリをクリアし、新しいものを追加
            Current.Resources.MergedDictionaries.Clear();
            AddResourceDictionaries();

            if (mahAppsAccentsColorMap.ContainsValue(primaryColor))
            {
                // リソースディクショナリの変更
                var themeName = mahAppsAccentsColorMap.GetKey(primaryColor);
                var mahAppsTheme = isDark ? $"Dark.{themeName}" : $"Light.{themeName}";
                var newResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/MahApps.Metro;component/Styles/Themes/{mahAppsTheme}.xaml")
                };
                Current.Resources.MergedDictionaries.Add(newResourceDictionary);
            }
            else
            {
                // マップにない場合のデフォルト処理
                var defaultTheme = isDark ? "Dark.Blue" : "Light.Blue";
                var newResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/MahApps.Metro;component/Styles/Themes/{defaultTheme}.xaml")
                };
                Current.Resources.MergedDictionaries.Add(newResourceDictionary);
            }
        }

        /// <summary>
        /// 必要なリソースディクショナリを追加します。
        /// </summary>
        private void AddResourceDictionaries()
        {
            /*
             App.xamlに記述されているリソースディクショナリ
            <!-- Material Design -->
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Defaults.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Secondary/MaterialDesignColor.Lime.xaml" />

            <!-- Material Design: MahApps統合設定 -->
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Fonts.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Flyout.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Defaults.xaml" />

            <!-- MahApps -->
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Themes/Light.Blue.xaml" />
            これを参考にして、リソースディクショナリを追加していく
            */
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Defaults.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Secondary/MaterialDesignColor.Lime.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Fonts.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Flyout.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Defaults.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml")
            });
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml")
            });
        }

    }

    /// <summary>
    /// DictionaryインスタンスへのGetKeyの拡張メソッド
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 指定された値に対応するキーを辞書から取得します。
        /// TKeyはnullを許容しない型である必要があります。
        /// </summary>
        /// <typeparam name="TKey">辞書のキーの型</typeparam>
        /// <typeparam name="TValue">辞書の値の型</typeparam>
        /// <param name="dictionary">検索対象の辞書</param>
        /// <param name="value">検索する値</param>
        /// <returns>値に対応するキー</returns>
        /// <exception cref="ArgumentException">辞書に値が存在しない場合にスローされます</exception>
        public static TKey GetKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
            where TKey : notnull
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value != null && pair.Value.Equals(value))
                {
                    return pair.Key;
                }
            }
            throw new ArgumentException("The value is not present in the dictionary.");
        }
    }
}
