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
