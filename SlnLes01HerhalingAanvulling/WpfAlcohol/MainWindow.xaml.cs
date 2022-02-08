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

namespace WpfAlcohol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double bier, wijn, whisky;
 
        private void SliderBier_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bier = Math.Round(SliderBier.Value);
            lblBier.Content = bier + " glazen";
            BerekenRechthoek();
        }

        private void SliderWijn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            wijn = Math.Round(SliderWijn.Value);
            lblWijn.Content = wijn + " glazen";
            BerekenRechthoek();
        }

        private void SliderWhisky_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            whisky = Math.Round(SliderWhisky.Value);
            lblWhisky.Content = whisky + " glazen";
            BerekenRechthoek();
        }

        private void BerekenRechthoek()
        {
            //lengte bepalen
            double aantalGlazen = bier + wijn + whisky;
            rctGehalte.Width = aantalGlazen * 20;

            //kleur bepalen
            double r = 17 * aantalGlazen;
            double g = 255 - (17 * aantalGlazen);
            rctGehalte.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r),Convert.ToByte(g), 0));
        }
    }
}
