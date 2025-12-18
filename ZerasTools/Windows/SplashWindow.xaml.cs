using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ZerasTools.Windows
{
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();

            DoubleAnimation anim = new DoubleAnimation(0, 360, new Duration(System.TimeSpan.FromSeconds(1)));
            anim.RepeatBehavior = RepeatBehavior.Forever;
            SpinnerRotate.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, anim);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = System.TimeSpan.FromSeconds(5);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            };
            timer.Start();
        }
    }
}
