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

namespace WpfPaswoordChecker
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

        private void txtWachtwoord_TextChanged(object sender, TextChangedEventArgs e)
        {
            string wachtwoord = txtWachtwoord.Text;
            SolidColorBrush rood = new SolidColorBrush(Colors.Red);
            ResetError(wachtwoord, rood);
            btnRegistreer.IsEnabled = ControleerWachtwoord();
        }

        private bool ControleerWachtwoord()
        {
            SolidColorBrush groen = new SolidColorBrush(Colors.Green);
            bool hulp = true;
            bool[] controle = new bool[5];

            //alle controles op false zetten
            for (int i = 0; i < controle.Length; i++)
            {
                controle[i] = false;
            }

            //Minimum 8 karakters lang
            if (txtWachtwoord.Text.Length>7)
            {
                controle[0] = true;
                lbl8karakters.Foreground = groen;
            }

            foreach (char karakter in txtWachtwoord.Text)
            {
                //Minimum één kleine letter
                if (System.Convert.ToInt32(karakter) < 123 && System.Convert.ToInt32(karakter)>96)
                {
                    controle[1] = true;
                    lblKleineLetter.Foreground = groen;
                }
                //Minimum één hoofdletter
                if (System.Convert.ToInt32(karakter) < 91 && System.Convert.ToInt32(karakter) > 64)
                {
                    controle[2] = true;
                    lblHoofdletter.Foreground = groen;
                }
                //Minimum één cijfer
                if (System.Convert.ToInt32(karakter) < 58 && System.Convert.ToInt32(karakter) > 47)
                {
                    controle[3] = true;
                    lblCijfer.Foreground = groen;
                }
                //Minimum één vreemd karakter
                if (System.Convert.ToInt32(karakter) < 48 && System.Convert.ToInt32(karakter) > 32 || 
                    System.Convert.ToInt32(karakter) < 65 && System.Convert.ToInt32(karakter) > 57 ||
                    System.Convert.ToInt32(karakter) < 127 && System.Convert.ToInt32(karakter) > 122)
                {
                    controle[4] = true;
                    lblVreemdKarakter.Foreground = groen;
                }
            }

            foreach (bool item in controle)
            {
                if (item == false)
                {
                    hulp=false;
                }
            }
            return hulp;
        }

        private void ResetError(string w, SolidColorBrush rood)
        {
            if (w != "")
            {
                lbl8karakters.Visibility = Visibility.Visible;
                lblKleineLetter.Visibility = Visibility.Visible;
                lblHoofdletter.Visibility = Visibility.Visible;
                lblCijfer.Visibility = Visibility.Visible;
                lblVreemdKarakter.Visibility = Visibility.Visible;
            }
            if (w == "")
            {
                lbl8karakters.Visibility = Visibility.Hidden;
                lblKleineLetter.Visibility = Visibility.Hidden;
                lblHoofdletter.Visibility = Visibility.Hidden;
                lblCijfer.Visibility = Visibility.Hidden;
                lblVreemdKarakter.Visibility = Visibility.Hidden;
            }
            lbl8karakters.Foreground = rood;
            lblKleineLetter.Foreground = rood;
            lblHoofdletter.Foreground = rood;
            lblCijfer.Foreground = rood;
            lblVreemdKarakter.Foreground = rood;
        }

        private void btnRegistreer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welkom");
            txtWachtwoord.Clear();
        }
    }
}
