# Material Design In XAML ToolkitとMahApps.Metroを使用する手順

## 前提条件
- Visual Studio Community 2022がインストールされている
- .NET 8 SDKがインストールされている

## 手順

### 1. 新しいWPFプロジェクトを作成

1. Visual Studio Community 2022を開きます。
2. 「新しいプロジェクトの作成」をクリックします。
3. 「WPFアプリケーション」を選択し、「次へ」をクリックします。
4. プロジェクト名と保存場所を指定し、「作成」をクリックします。
5. ターゲットフレームワークとして「.NET 8」を選択し、「作成」をクリックします。

### 2. Material Design In XAML Toolkitのインストール

1. ソリューションエクスプローラーでプロジェクトを右クリックし、「NuGetパッケージの管理」を選択します。
2. 「参照」タブを選択し、検索ボックスに「MaterialDesignThemes」を入力します。
3. 「MaterialDesignThemes」パッケージを選択し、バージョンを確認して「インストール」をクリックします。
4. 同様に、「MaterialDesignColors」、「MaterialDesignThemes.MahApps」パッケージもインストールします。

### 3. MahApps.Metroのインストール

1. ソリューションエクスプローラーでプロジェクトを右クリックし、「NuGetパッケージの管理」を選択します。
2. 「参照」タブを選択し、検索ボックスに「MahApps.Metro」を入力します。
3. 「MahApps.Metro」パッケージを選択し、バージョンを確認して「インストール」をクリックします。
4. 同様に、「MahApps.Metro.IconPacks」パッケージもインストールします。


### 4. Material Design In XAML ToolkitとMahApps.Metroの設定

1. `App.xaml`ファイルを開きます。
2. 以下のリソースディクショナリを`<Application.Resources>`セクションに追加します：
    ```xaml
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
    ```
    修正後の `App.xaml` は以下となります。
    ```xml
    <Application x:Class="BeginMaterialDesignWithMetro.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:BeginMaterialDesignWithMetro"
                 StartupUri="MainWindow.xaml">
        <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
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

                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </Application.Resources>
    </Application>
    ```

### 5. メインウィンドウのデザインを更新

1. `MainWindow.xaml`ファイルを開きます。
2. Material Design In XAML Toolkitの名前空間定義を追加します。
    ```
    xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
    ```
3. MahApps.Metroの名前空間定義と設定を追加します。
    ```
    xmlns:metro="http://metro.mahapps.com/winfx/xaml/controls"
    TextElement.Foreground="{DynamicResource MaterialDesignBody}"
    Background="{DynamicResource MaterialDesignPaper}"
    FontFamily="{DynamicResource MaterialDesignFont}"
    GlowBrush="{DynamicResource MahApps.Brushes.Accent}"
    ```

4. MahApps.Metroスタイルのウィンドウに変更します
    ```xml
    <metro:MetroWindow x:Class="BeginMaterialDesignWithMetro.MainWindow"
    ...省略
    >
    </metro:MetroWindow>
    ```

5. Material Design In XAML ToolkitとMahApps.Metroのボタンを追加します。
    ```xml
    <Button Content="Accent Button"
            Style="{StaticResource MahApps.Styles.Button.Square.Accent}"
            Margin="10"
            Height="40"
            Width="200" />

    <Button Content="Circle Button"
            Style="{DynamicResource MahApps.Styles.Button.Circle}"
            Margin="10"
            Height="40"
            Width="200" />

    <Button Content="Material DesignPaper LightButton"
            Margin="10"
            Style="{StaticResource  MaterialDesignPaperLightButton}" />
    <Button Content="Material Design Button"
            Margin="10"
            Style="{StaticResource MaterialDesignRaisedButton}" />

    <ToggleButton x:Name="ThemeToggleButton"
                  Content="Toggle Theme"
                  Width="200"
                  Margin="10"
                  Style="{DynamicResource MetroCircleToggleButtonStyle}"
                  Checked="ThemeToggleButton_Checked"
                  Unchecked="ThemeToggleButton_Unchecked"/>
    ```
    
    追加後の `MainWindow.xaml` は以下となります。

    ```
    <metro:MetroWindow x:Class="BeginMaterialDesignWithMetro.MainWindow"
                       xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                       xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                       xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                       xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                       xmlns:local="clr-namespace:BeginMaterialDesignWithMetro"
                       mc:Ignorable="d"
                       Title="MainWindow" Height="450" Width="800"
                       xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
                       xmlns:metro="http://metro.mahapps.com/winfx/xaml/controls"
                       xmlns:Dialog="clr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro"
                       TextElement.Foreground="{DynamicResource MaterialDesignBody}"
                       Background="{DynamicResource MaterialDesignPaper}"
                       FontFamily="{DynamicResource MaterialDesignFont}"
                       GlowBrush="{DynamicResource MahApps.Brushes.Accent}"
    >
        <Grid>
            <StackPanel>
                <Button Content="Accent Button"
                        Style="{StaticResource MahApps.Styles.Button.Square.Accent}"
                        Margin="10"
                        Height="40"
                        Width="200" />

                <Button Content="Circle Button"
                        Style="{DynamicResource MahApps.Styles.Button.Circle}"
                        Margin="10"
                        Height="40"
                        Width="200" />

                <Button Content="Material DesignPaper LightButton"
                        Margin="10"
                        Style="{StaticResource  MaterialDesignPaperLightButton}" />
                <Button Content="Material Design Button"
                        Margin="10"
                        Style="{StaticResource MaterialDesignRaisedButton}" />
                
                <ToggleButton x:Name="ThemeToggleButton"
                              Content="Toggle Theme"
                              Width="200"
                              Margin="10"
                              Style="{DynamicResource MetroCircleToggleButtonStyle}"
                              Checked="ThemeToggleButton_Checked"
                              Unchecked="ThemeToggleButton_Unchecked"/>
            </StackPanel>
        </Grid>
    </metro:MetroWindow>
    ```


### 6. App.xaml.csの修正

1. `App.xaml.cs`ファイルを開きます。
2. テーマの設定変更処理を追加します。：

    ```csharp
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

    ```
### 7. MainWindow.xaml.csの修正

1. `MainWindow.xaml.cs`ファイルを開きます。
2. イベントハンドラによるテーマの設定変更処理を追加します。：

    ```csharp
    using ControlzEx.Theming;
    using MahApps.Metro.Controls;
    using MaterialDesignColors;
    using MaterialDesignThemes.Wpf;
    using System.Windows;
    using System.Windows.Media;
    
    namespace BeginMaterialDesignWithMetro
    {
        public partial class MainWindow : MetroWindow
        {
            private readonly App _app;
    
            public MainWindow()
            {
                InitializeComponent();
                _app = (App)Application.Current;
            }
    
            private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
            {
                _app.SetTheme(Colors.Red, Colors.Lime, true);
            }
    
            private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
            {
                _app.SetTheme(Colors.Red, Colors.Lime, false);
            }
        }
    }

    ````
### 8. アプリケーションの実行

1. Visual Studioで`F5`キーを押してアプリケーションをビルドし、実行します。
2. MahApps.Metroスタイルが適用されたウィンドウとボタンが表示されることを確認します。

以上で、WPFアプリケーションにMaterial Design In XAML ToolkitとMahApps.Metroを適用する手順は完了です。

