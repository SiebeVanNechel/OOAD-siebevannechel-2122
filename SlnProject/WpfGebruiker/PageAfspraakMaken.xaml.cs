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
        int loginid;
        Dokter selectedDokter;
        public PageAfspraakMaken(int id)
        {
            InitializeComponent();
            loginid = id;
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            PageOverzichtAfspraken page = new PageOverzichtAfspraken(loginid);
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
            if (CmbDokters.SelectedIndex!=-1)
            {
                string[] naam = CmbDokters.SelectedItem.ToString().Split(' ');
                selectedDokter = Dokter.FindByName(naam[1]);

                lblNaam.Content = selectedDokter.Voornaam + " " + selectedDokter.Achternaam;
                lblEmail.Content = selectedDokter.Email;
                lblGsm.Content = selectedDokter.Gsm;
                ImgFotoDokter.Source = selectedDokter.Profielfotodata == null ? new BitmapImage(new Uri("Img/DefaultAvatar.png", UriKind.Relative)) : selectedDokter.Profielfotodata;
            }
        }

        private void btnBevestigen_Click(object sender, RoutedEventArgs e)
        {
            DateTime moment = Convert.ToDateTime(DatePickerMoment.SelectedDate.ToString()).Add(TimeSpan.Parse(CombooxUur.Text));
            string klacht = txtRedenConsultatie.Text;
            int patientid = loginid;
            int dokterid = selectedDokter.Id;            
 
            Afspraak afspraak = new Afspraak(0,moment, klacht, patientid, dokterid);
            int newId = afspraak.InsertToDb();

            CmbDokters.SelectedIndex = -1;
            DatePickerMoment.SelectedDate = null;
            txtRedenConsultatie.Text = "";
            CombooxUur.SelectedIndex = -1;
            ImgFotoDokter.Source = new BitmapImage(new Uri("Img/DefaultAvatar.png", UriKind.Relative));
            lblEmail.Content = "";
            lblGsm.Content = "";
            lblNaam.Content = "";
        }
    }
}
