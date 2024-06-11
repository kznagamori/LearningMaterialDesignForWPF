# Material Design In XAML ToolkitとMahApps.Metroを使用したアプリケーション作成のベース


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
4. 同様に、「MaterialDesignThemes.MahApps」パッケージもインストールします。

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
    <Application x:Class="MaterialMetroAppBase.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:MaterialMetroAppBase"
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
    xmlns:iconPacks="http://metro.mahapps.com/winfx/xaml/iconpacks"
    ```

4. MahApps.Metroスタイルのウィンドウに変更します
    ```xml
    <metro:MetroWindow x:Class="MaterialMetroAppBase.MainWindow"
    ...省略
    >
    </metro:MetroWindow>
    ```

    追加後の `MainWindow.xaml` は以下となります。
    ```xml
    <metro:MetroWindow x:Class="MaterialMetroAppBase.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:MaterialMetroAppBase"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800"
            xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
            xmlns:metro="http://metro.mahapps.com/winfx/xaml/controls"
            TextElement.Foreground="{DynamicResource MaterialDesignBody}"
            Background="{DynamicResource MaterialDesignPaper}"
            FontFamily="{DynamicResource MaterialDesignFont}"
            GlowBrush="{DynamicResource MahApps.Brushes.Accent}"
            xmlns:iconPacks="http://metro.mahapps.com/winfx/xaml/iconpacks"
    >
        <Grid>
            <StackPanel>
                <Button Content="MahApps.Metro Button"
                        Style="{StaticResource MahApps.Styles.Button.Square.Accent}"
                        Height="40"
                        Width="200">
                </Button>
                <iconPacks:PackIconModern
                    Width="60"
                    Height="60"
                    Kind="Home" />
                <Button Content="Material Design Button"
                        Margin="10"
                        Style="{StaticResource MaterialDesignRaisedButton}">
                </Button>
                <materialDesign:PackIcon 
                    Width="60"
                    Height="60"                
                    Kind="Home" />
            </StackPanel>
        </Grid>
    </metro:MetroWindow>
    ```

### 6. \.configファイルでのテーマカラー設定
1. ソリューションエクスプローラーでプロジェクトを選択します。
2. 「プロパティ」をクリックします。
3. 「設定」をクリックし、設定の全般に移動します。
4. 「アプリケーション設定を作成する/開く」をクリックします。
5. Settengs.settingのアプリケーション設定に以下を追加した。
    - 名前=PrimaryColor、種類=string、値=Blue
    - 名前=SecondaryColor、種類=string、値=Lime
    `Properties\Settings.settings`は以下となります。
    ```xml
    <?xml version='1.0' encoding='utf-8'?>
    <SettingsFile xmlns="http://schemas.microsoft.com/VisualStudio/2004/01/settings" CurrentProfile="(Default)" GeneratedClassNamespace="MaterialMetroAppBase.Properties" GeneratedClassName="Settings">
      <Profiles />
      <Settings>
        <Setting Name="PrimaryColor" Type="System.String" Scope="User">
          <Value Profile="(Default)">Colors.Red</Value>
        </Setting>
        <Setting Name="SecondaryColor" Type="System.String" Scope="User">
          <Value Profile="(Default)"> Colors.Lime</Value>
        </Setting>
      </Settings>
    </SettingsFile>
    ```

### 6. App.xaml.csの修正

1. `App.xaml.cs`ファイルを開きます。
2. テーマの設定変更処理を追加します。
    ```csharp
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
    ```

### 7. MainWindow.xaml.csの修正

1. `MainWindow.xaml.cs`ファイルを開きます。
2. MahApps.Metroスタイルのウィンドウに変更します
    ```csharp
    using ControlzEx.Theming;
    using MahApps.Metro.Controls;
    using MaterialDesignColors;
    using MaterialDesignThemes.Wpf;
    using System.Windows;
    using System.Windows.Media;
    
    namespace MaterialMetroAppBase
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : MetroWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }
    ```

### 8. プロジェクトファイルの編集
プロジェクトファイル（.csproj）を編集して、必要な設定を追加します。

1. ソリューションエクスプローラーでプロジェクトを右クリックし、**プロジェクトファイルの編集**を選択します。
2. `<PropertyGroup>`セクションに以下の設定を追加します：
    ```xml
    <SelfContained>true</SelfContained>
    <PublishSingleFile>true</PublishSingleFile>
    <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
    <EnableCompressionInSingleFile>true</EnableCompressionInSingleFile>
    ```
    修正後のプロジェクトファイル（.csproj）は以下となります。
    ```xml
    <Project Sdk="Microsoft.NET.Sdk">
    
      <PropertyGroup>
        <OutputType>WinExe</OutputType>
        <TargetFramework>net8.0-windows</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
        <UseWPF>true</UseWPF>
        <SelfContained>true</SelfContained>
        <PublishSingleFile>true</PublishSingleFile>
        <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
        <EnableCompressionInSingleFile>true</EnableCompressionInSingleFile>
      </PropertyGroup>
    
      <ItemGroup>
        <PackageReference Include="MahApps.Metro" Version="2.4.10" />
        <PackageReference Include="MahApps.Metro.IconPacks" Version="5.0.0" />
        <PackageReference Include="MaterialDesignThemes" Version="5.0.0" />
        <PackageReference Include="MaterialDesignThemes.MahApps" Version="1.0.0" />
      </ItemGroup>
    
      <ItemGroup>
        <Compile Update="Properties\Settings.Designer.cs">
          <DesignTimeSharedInput>True</DesignTimeSharedInput>
          <AutoGen>True</AutoGen>
          <DependentUpon>Settings.settings</DependentUpon>
        </Compile>
      </ItemGroup>
    
      <ItemGroup>
        <None Update="Properties\Settings.settings">
          <Generator>SettingsSingleFileGenerator</Generator>
          <LastGenOutput>Settings.Designer.cs</LastGenOutput>
        </None>
      </ItemGroup>
    
    </Project>
    ```


### 8. 発行・publishの設定
1. ソリューションエクスプローラーでプロジェクトを選択します。
2. 「発行」をクリックします。
3. 「ターゲット」にフォルダーを選択します。
4. 「特定のターゲット」にフォルダーを選択します。
5. 「場所」の「フォルダーの場所」に `bin\Release\publish\` を設定します。
6. 「完了」クリックします。
7. 「すべての設定を表示」をクリックし以下を設定します。
    - ターゲットフレームワーク: net8.0-windows
    - 配置モード: 自己完結
    - ターゲットランタイム: win-x64

