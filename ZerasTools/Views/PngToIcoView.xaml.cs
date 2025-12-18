using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using ZerasTools.Services;

namespace ZerasTools.Views
{
    public partial class PngToIcoView : UserControl
    {
        private string selectedImage;

        public PngToIcoView()
        {
            InitializeComponent();

            ConvertButton.IsEnabled = false;

            BrowseButton.Click += BrowseButton_Click;
            ConvertButton.Click += ConvertButton_Click;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Images (*.png;*.jpg)|*.png;*.jpg"
            };

            if (ofd.ShowDialog() == true)
            {
                selectedImage = ofd.FileName;
                ConvertButton.IsEnabled = true;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImage)) return;

            string outPath = Path.Combine(
                Path.GetDirectoryName(selectedImage),
                Path.GetFileNameWithoutExtension(selectedImage) +
                " {Converted by Zera}.ico");

            new PngJpgToIco().Convert(selectedImage, outPath);
            MessageBox.Show($"ICO created at:\n{outPath}", "Success");
        }
    }
}
