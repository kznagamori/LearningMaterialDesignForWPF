using System.Windows;
using System.Windows.Media;
using ControlzEx.Theming;
using MaterialDesignThemes.Wpf;

namespace BeginMaterialDesignWithMetro
{
    public partial class App : Application
    {
        private readonly Dictionary<Color, string> colorThemeMap = new Dictionary<Color, string>
        {
            { Colors.Blue, "Blue" },
            { Colors.Red, "Red" },
            { Colors.Green, "Green" },
            { Colors.Purple, "Purple" },
            { Colors.Orange, "Orange" },
            { Colors.Cyan, "Cyan" },
            { Colors.Lime, "Lime" },
            { Colors.Pink, "Pink" },
            { Colors.Teal, "Teal" },
            { Colors.Yellow, "Yellow" },
            // 必要に応じて他のカラーも追加
        };
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetTheme(Colors.Red, Colors.Lime, false);
        }
        public void SetTheme(Color primaryColor, Color secondaryColor, bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDark ? BaseTheme.Dark : BaseTheme.Light);
            theme.SetPrimaryColor(primaryColor);
            theme.SetSecondaryColor(secondaryColor);
            paletteHelper.SetTheme(theme);

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
            */

            if (colorThemeMap.TryGetValue(primaryColor, out string themeName))
            {
                // 現在のリソースディクショナリをクリアし、新しいものを追加
                Current.Resources.MergedDictionaries.Clear();

                // App.xamlに記述されているリソースディクショナリを追加
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



                // リソースディクショナリの変更
                var mahAppsTheme = isDark ? $"Dark.{themeName}" : $"Light.{themeName}";
                var newResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/MahApps.Metro;component/Styles/Themes/{mahAppsTheme}.xaml")
                };
                Current.Resources.MergedDictionaries.Add(newResourceDictionary);
            }
            else
            {
                // 現在のリソースディクショナリをクリアし、新しいものを追加
                Current.Resources.MergedDictionaries.Clear();

                // App.xamlに記述されているリソースディクショナリを追加
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

                // マップにない場合のデフォルト処理
                var defaultTheme = isDark ? "Dark.Blue" : "Light.Blue";
                var newResourceDictionary = new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/MahApps.Metro;component/Styles/Themes/{defaultTheme}.xaml")
                };
                Current.Resources.MergedDictionaries.Add(newResourceDictionary);


            }
        }
    }
}
