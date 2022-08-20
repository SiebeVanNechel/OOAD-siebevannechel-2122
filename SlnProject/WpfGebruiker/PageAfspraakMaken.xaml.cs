using System;
using System.Collections.Generic;
using System.Configuration;
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
using DokterspraktijkClassLibrary;

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for PageAfspraakMaken.xaml
    /// </summary>
    public partial class PageAfspraakMaken : Page
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        //int loginid;
        public PageAfspraakMaken()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            PageOverzichtAfspraken page = new PageOverzichtAfspraken();
            this.NavigationService.Navigate(page);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Dokter> dokters = Dokter.GetAll();
     
            foreach(Dokter dokter in dokters)
            {
                CmbDokters.Items.Add("Dr. " + dokter.Voornaam + " " + dokter.Achternaam);
            }
        }

        private void CmbDokters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] naam = CmbDokters.SelectedItem.ToString().Split(' ');
            Dokter dokter = Dokter.FindByName(naam[1]);

            lblNaam.Content = dokter.Voornaam + " " + dokter.Achternaam;
            lblEmail.Content = "Dr. " + dokter.Email;
            lblGsm.Content = dokter.Gsm;
            ImgFotoDokter.Source = dokter.Profielfotodata == null ? new BitmapImage(new Uri("Img/DefaultAvatar.png", UriKind.Relative)) : dokter.Profielfotodata;
        }
    }
}
