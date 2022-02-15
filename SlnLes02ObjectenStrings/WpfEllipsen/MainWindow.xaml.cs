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

namespace WpfEllipsen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxRadius, minRadius, aantalEllips;
        private int ticks;
        private DispatcherTimer timer;
        Random rdn = new Random();

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Teken;
            /*
            // maak de ellips
            Ellipse newEllipse = new Ellipse();
            newEllipse.Width = 150;
            newEllipse.Height = 60;
            newEllipse.Fill = new SolidColorBrush(Color.FromRgb(122, 78, 200));
            double xPos = 50;
            double yPos = 85;
            newEllipse.SetValue(Canvas.LeftProperty, xPos);
            newEllipse.SetValue(Canvas.TopProperty, yPos);
            //voeg ellips toe aan het canvas
            canvas1.Children.Add(newEllipse);
            */
        }

        private void SliderAantal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblSlider1.Content = SliderAantal.Value;
        }

        private void SliderMin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblSlider2.Content = SliderMin.Value;
        }

        private void SliderMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblSlider3.Content = SliderMax.Value;

        }

        private void Teken(object sender, EventArgs e)
        {
            if (ticks <= aantalEllips)
            {
                // maak de ellips
                Ellipse newEllipse = new Ellipse();
                newEllipse.Width = rdn.Next(minRadius, maxRadius);
                newEllipse.Height = rdn.Next(minRadius, maxRadius);
                newEllipse.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rdn.Next(0, 255)), Convert.ToByte(rdn.Next(0, 255)), Convert.ToByte(rdn.Next(0, 255))));
                double xPos = rdn.Next(20, 700);
                double yPos = rdn.Next(20, 200);
                newEllipse.SetValue(Canvas.LeftProperty, xPos);
                newEllipse.SetValue(Canvas.TopProperty, yPos);
                //voeg ellips toe aan het canvas
                canvas1.Children.Add(newEllipse);
            }
            else
            {
                timer.Stop();
                ticks = 0;
            }
            ticks++;
        }

            private void btnTekenen_Click(object sender, RoutedEventArgs e)
        {

            /*   const int AANTAL_ELLIPSEN = 50;
               const int MIN_RADIUS = 40;
               const int MAX_RADIUS = 150;
               Random rdn = new Random();
               for (int i = 0; i < AANTAL_ELLIPSEN; i++)
               {
                   // maak de ellips
                   Ellipse newEllipse = new Ellipse();
                   newEllipse.Width = rdn.Next(MIN_RADIUS,MAX_RADIUS);
                   newEllipse.Height = rdn.Next(MIN_RADIUS, MAX_RADIUS);
                   newEllipse.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rdn.Next(0, 255)), Convert.ToByte(rdn.Next(0, 255)), Convert.ToByte(rdn.Next(0, 255))));
                   double xPos = rdn.Next(20,700);
                   double yPos = rdn.Next(20, 200);
                   newEllipse.SetValue(Canvas.LeftProperty, xPos);
                   newEllipse.SetValue(Canvas.TopProperty, yPos);
                   //voeg ellips toe aan het canvas
                   canvas1.Children.Add(newEllipse);

               }*/
            aantalEllips = Convert.ToInt32(SliderAantal.Value);
            minRadius = Convert.ToInt32(SliderMin.Value);
            maxRadius = Convert.ToInt32(SliderMax.Value);
            if (minRadius > maxRadius)
            {
                SolidColorBrush rood = new SolidColorBrush(Colors.Red);
                lblFoutmelding.Foreground = rood;
                lblFoutmelding.Content = "De minimum straal mag niet groter zijn dan de maximum straal!";
            }
            else
            {
                timer.Start();
                lblFoutmelding.Content = "";
            }
        }
    }
}
