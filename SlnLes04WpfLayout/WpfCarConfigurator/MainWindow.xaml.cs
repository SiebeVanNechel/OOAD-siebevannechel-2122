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

namespace WpfCarConfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImgAudio.Source = new BitmapImage(new Uri($"Images/opties_audio.jpg", UriKind.Relative));
            ImgMatjes.Source = new BitmapImage(new Uri($"Images/opties_matjes.jpg", UriKind.Relative));
            ImgVelgen.Source = new BitmapImage(new Uri($"Images/opties_velgen.jpg", UriKind.Relative));
        }

        private void CmbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void RadiobtnBlauw_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void RadiobtnGroen_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI(); 
            BerekenPrijs();
        }

        private void RadiobtnRood_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void UpdateUI() 
        {
            string foto = "";
            if (CmbModel.SelectedIndex == 0)
            {
                foto = "model1_";
            }
            if (CmbModel.SelectedIndex == 1)
            {
                foto = "model2_";
            }
            if (CmbModel.SelectedIndex == 2)
            {
                foto = "model3_";
            }

            if (RadiobtnBlauw.IsChecked==true)
            {
                foto += "blauw";
            }
            if (RadiobtnGroen.IsChecked == true)
            {
                foto += "groen";
            }
            if (RadiobtnRood.IsChecked == true)
            {
                foto += "rood";
            }
            ImgAuto.Source = new BitmapImage(new Uri($"Images/{foto}.jpg", UriKind.Relative));

            ImgAudio.Opacity = CheckAudio.IsChecked==true ? ImgAudio.Opacity = 1 : ImgAudio.Opacity = 0.3;
            ImgMatjes.Opacity = CheckMatjes.IsChecked == true ? ImgMatjes.Opacity = 1 : ImgMatjes.Opacity = 0.3;
            ImgVelgen.Opacity = CheckVelgen.IsChecked == true ? ImgVelgen.Opacity = 1 : ImgVelgen.Opacity = 0.3;

        }

        private void BerekenPrijs()
        {
            int prijs = 0;
            if (CmbModel.SelectedIndex == 0)
            {
                prijs=85000;
            }
            if (CmbModel.SelectedIndex == 1)
            {
                prijs=72000;
            }
            if (CmbModel.SelectedIndex == 2)
            {
                prijs=65300;
            }

            if (RadiobtnGroen.IsChecked == true)
            {
                prijs+=250;
            }
            if (RadiobtnRood.IsChecked == true)
            {
                prijs+=700;
            }

            if (CheckAudio.IsChecked==true)
            {
                prijs += 1250;
            }
            if (CheckMatjes.IsChecked==true)
            {
                prijs += 450;
            }
            if (CheckVelgen.IsChecked==true)
            {
                prijs += 300;
            }
            lblPrijs.Content = prijs + " euro";
        }

        private void CheckAudio_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void CheckMatjes_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void CheckVelgen_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void CheckAudio_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void CheckMatjes_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void CheckVelgen_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }

        private void RadiobtnBlauw_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            BerekenPrijs();
        }
    }

    //private int BerekenPrijs()
    //{
    //    int res=0;

    //    return res; 
    //}
}
