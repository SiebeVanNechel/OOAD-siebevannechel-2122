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
    /// Interaction logic for PageEditPatiënt.xaml
    /// </summary>
    public partial class PageEditPatiënt : Page
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        int patientId;
        public PageEditPatiënt(int Patientid)
        {
            InitializeComponent();
            patientId = Patientid;
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
            txtVoornaam.Text = patient.Voornaam;
            txtFamilienaam.Text = patient.Achternaam;
            if (patient.Geslacht.ToString() == "Man") RadioMan.IsChecked = true;
            if (patient.Geslacht.ToString() == "Vrouw") RadioVrouw.IsChecked = true;
            DatePickerGeboortedatum.SelectedDate = patient.Geboortedatum;
            lblEmail.Content = patient.Email;
            lblGsm.Content = patient.Gsm;
            ImgFotoPatient.Source = patient.Profielfotodata == null ? new BitmapImage(new Uri("Img/DefaultAvatar.png", UriKind.Relative)) : patient.Profielfotodata;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = Patient.FindById(patientId);
            string voornaam = txtVoornaam.Text;
            string achternaam = txtFamilienaam.Text;
            DateTime geboortedatum = DatePickerGeboortedatum.SelectedDate.Value;
            int geslacht = 0;
            if (RadioMan.IsChecked==true) geslacht = 1;
            if (RadioVrouw.IsChecked==true) geslacht = 2;

            patient.UpdateInDbDoorDokter(patientId,voornaam, achternaam, geslacht, geboortedatum);

            PageOverzichtPatiënten page = new PageOverzichtPatiënten();
            this.NavigationService.Navigate(page);
        }
    }
}
