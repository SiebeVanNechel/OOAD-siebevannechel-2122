using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private int seconden = 0;
        private int minuten = 5;
        public MainWindow()
        {
            InitializeComponent();
            lblTijd.Content = seconden;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            lblTijd.Content = minuten + ":" + seconden;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            seconden--;
            if (seconden ==-1)
            {
                minuten--;
                seconden = 59;
            }
            lblTijd.Content = minuten + ":" + seconden;

            if (minuten==0 && seconden ==0)
            {
                timer.Stop();
                btnStop.IsEnabled = false;
            }

            window.Background = new SolidColorBrush(Color.FromRgb(255,Convert.ToByte(minuten*20),Convert.ToByte(seconden*4)));   

            rctMinuten.Height = minuten * 20;
            rctSeconden.Height = seconden * 1.66666;
           
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            btnStop.IsEnabled=true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            btnReset.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            seconden = 59;
            minuten = 4;
            btnReset.IsEnabled = false;
            btnStop.IsEnabled = false;
            lblTijd.Content = 5 + ":" + 0;
            rctMinuten.Height = 100;
            rctSeconden.Height = 100;
            window.Background = new SolidColorBrush(Color.FromRgb(255, 255,255));
        }
    }
}
