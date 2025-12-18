using System.Windows;
using ZerasTools.Windows;

namespace ZerasTools
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new SplashWindow().Show();
        }
    }
}
