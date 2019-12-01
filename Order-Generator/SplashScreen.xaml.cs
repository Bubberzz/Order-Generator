using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Order_Generator
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public SplashScreen()
        {
            InitializeComponent();
           
            mediaPlay();
            splashScreen();
        }

        private async void splashScreen()
        {
            var mn = new MainWindow();
            await Task.Run(() => mn.loadData());
            await Task.Delay(20000);
            Close();
            mn.Show();
        }

        private void mediaPlay()
        {
            media.Source = new Uri(Environment.CurrentDirectory + @"\Loading.gif");
            media.Play();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = new TimeSpan(0, 0, 1);
            media.Play();
        }


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
