using DokterspraktijkClassLibrary;
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

namespace WpfDokter
{
    /// <summary>
    /// Interaction logic for PageInfoPatiënt.xaml
    /// </summary>
    public partial class PageInfoPatiënt : Page
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        int patientId;
        public PageInfoPatiënt(int PatientId)
        {
            InitializeComponent();
            patientId = PatientId;
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            PageOverzichtPatiënten page = new PageOverzichtPatiënten();
            this.NavigationService.Navigate(page);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // vul gegevens
            Patient patient = Patient.FindById(patientId);
            lblVoornaam.Content = patient.Voornaam;
            lblAchternaam.Content = patient.Achternaam;
            lblGeslacht.Content = patient.Geslacht;
            lblGeboortedatum.Content = patient.Geboortedatum.ToString("dd/MM/yyyy");
            lblEmail.Content = patient.Email;
            lblGsm.Content = patient.Gsm;
            ImgFotoPatient.Source = patient.Profielfotodata == null ? new BitmapImage(new Uri("Img/DefaultAvatar.png", UriKind.Relative)) : patient.Profielfotodata;
        }
    }
}
