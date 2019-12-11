using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Order_Generator
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            StartSplashScreen();
            LoadMAinWindow();
        }

        // Loads Main Window asynchronously, then closes Splash Screen once loaded
        private async void LoadMAinWindow()
        {
            var mn = new MainWindow();
            await Task.Run(() => mn.loadData());
            //await Task.Delay(5000);
            Close();
            media.Stop();
            mn.Show();
        }

        // Starts the Splash Screen 
        private void StartSplashScreen()
        {
            media.Source = new Uri(@"C:\Program Files (x86)\Asos\Order Generator\loading.gif");
            media.Play();
        }

        // Restarts the gif loop when it ends
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = new TimeSpan(0, 0, 1);
            media.Play();
        }

        // Allows the window to be dragged
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
                //ignored
            }
        }
    }
}
