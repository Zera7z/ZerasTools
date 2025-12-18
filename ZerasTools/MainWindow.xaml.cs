using System.Windows;
using System.Windows.Controls;
using ZerasTools.Views;
using ZerasTools.Windows;

namespace ZerasTools
{
    public partial class MainWindow : Window
    {
        private HomeView homeView;
        private PngToIcoView icoView;

        public MainWindow()
        {
            InitializeComponent();

            homeView = new HomeView();
            icoView = new PngToIcoView();

            // Default page = Home
            ToolTitle.Text = "Home";
            MainContent.Content = homeView;

            SettingsButton.Click += SettingsButton_Click;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ToolTitle.Text = "Home";
            MainContent.Content = homeView;
        }

        private void ImageToIcoButton_Click(object sender, RoutedEventArgs e)
        {
            ToolTitle.Text = "Image to ICO";
            MainContent.Content = icoView;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Owner = this;
            settings.ShowDialog();
        }

        private void TitleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
