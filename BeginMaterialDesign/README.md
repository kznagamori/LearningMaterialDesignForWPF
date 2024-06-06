# WPFアプリケーションでMaterial Design In XAML Toolkitを使用する手順

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
4. 同様に、「MaterialDesignColors」パッケージもインストールします。

### 3. Material Designの設定

1. `App.xaml`ファイルを開きます。
2. 以下のリソースディクショナリを`<Application.Resources>`セクションに追加します：

    ```xml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Defaults.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Secondary/MaterialDesignColor.Lime.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
    ```

### 4. メインウィンドウのデザインを更新

1. `MainWindow.xaml`ファイルを開きます。
2. 以下のXAMLコードに `xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"` を追加して、Material Designボタンを追加します：

    ```xml
    <Window x:Class="BeginMaterialDesign.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:BeginMaterialDesign"
            xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800">
        <Grid>
            <Button Content="Material Design Button" Style="{StaticResource MaterialDesignRaisedButton}" />
        </Grid>
    </Window>
    ```

### 5. アプリケーションの実行

1. Visual Studioで`F5`キーを押してアプリケーションをビルドし、実行します。
2. Material Designスタイルが適用されたボタンが表示されることを確認します。

以上で、WPFアプリケーションにMaterial Design In XAML Toolkitを適用する手順は完了です。

## Appendix

Visual Studio Community 2022でWPFの.NET 8プロジェクトを設定し、以下の要件を満たす方法を説明します。

1. **可能な限り作成されるバイナリを1つにまとめる**
2. **デプロイ先に別途.NETのインストールを要求しない**

### 手順

#### 1. プロジェクトの作成
まず、Visual Studio Community 2022で新しいWPFプロジェクトを作成します。

1. **ファイル** > **新規作成** > **プロジェクト**を選択します。
2. **WPFアプリケーション (.NET)** テンプレートを選択し、プロジェクト名を入力して**作成**をクリックします。

#### 2. プロジェクトファイルの編集
プロジェクトファイル（.csproj）を編集して、必要な設定を追加します。

1. ソリューションエクスプローラーでプロジェクトを右クリックし、**プロジェクトファイルの編集**を選択します。
2. `<PropertyGroup>`セクションに以下の設定を追加します：

```xml
<PropertyGroup>
  <TargetFramework>net8.0</TargetFramework>
  <SelfContained>true</SelfContained>
  <PublishSingleFile>true</PublishSingleFile>
  <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
  <EnableCompressionInSingleFile>true</EnableCompressionInSingleFile>
</PropertyGroup>
```

これにより、プロジェクトは自己完結型の単一ファイルとして公開され、ネイティブライブラリも含まれます。

#### 3. パブリッシュプロファイルの作成
次に、パブリッシュプロファイルを作成して設定を行います。

1. ソリューションエクスプローラーでプロジェクトを右クリックし、**発行**を選択します。
2. **新しいプロファイルの作成**を選択し、**フォルダー**を選択します。
3. **ターゲットランタイム**を`win-x64`などの適切なランタイムに設定し、**配置モード**を**自己完結型**を選択します。
4. **ファイルの発行オプション**で**単一ファイルの生成**をチェックします。

#### 4. パブリッシュの実行
設定が完了したら、プロジェクトをパブリッシュします。

1. **発行**ボタンをクリックして、プロジェクトをパブリッシュします。
2. パブリッシュされたフォルダーに移動し、生成された単一の.exeファイルを確認します。



