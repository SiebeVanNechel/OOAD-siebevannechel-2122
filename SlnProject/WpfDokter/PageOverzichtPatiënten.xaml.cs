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
    /// Interaction logic for PageOverzichtPatiënten.xaml
    /// </summary>
    public partial class PageOverzichtPatiënten : Page
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        //int loginId;
        public PageOverzichtPatiënten()
        {
            InitializeComponent();
            //loginId = id;
        }

        private void btnInfoPatien_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)ListBoxPatienten.SelectedItem;
            PageInfoPatiënt page = new PageInfoPatiënt(Convert.ToInt32(selectedItem.Tag));
            this.NavigationService.Navigate(page);
        }

        private void btnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)ListBoxPatienten.SelectedItem;
            PageEditPatiënt page = new PageEditPatiënt(Convert.ToInt32(selectedItem.Tag));
            this.NavigationService.Navigate(page);
        }

        private void btnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            // vraag id geselecteerde afspraak op
            ListBoxItem item = (ListBoxItem)ListBoxPatienten.SelectedItem;
            int patientid = Convert.ToInt32(item.Tag);
            Patient patient = Patient.FindById(patientid);

            // vraag bevestiging
            MessageBoxResult result = MessageBox.Show($"Ben je zeker dat u patient {patient.Voornaam} {patient.Achternaam} wilt verwijderen?", "Patient verwijderen", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            // verwijder patient
            patient.DeleteFromDb();

            // reload patienten
            ListBoxPatienten.SelectedIndex = -1;
            ListBoxPatienten.Items.Clear();
            List<Patient> patientenReload = Patient.GetAll();
            foreach (Patient patientReload in patientenReload)
            {
                ListBoxItem itemReload = new ListBoxItem();
                itemReload.Content = patientReload.Voornaam + " " + patientReload.Achternaam;
                itemReload.Tag = patientReload.Id;
                ListBoxPatienten.Items.Add(itemReload);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ListBoxPatienten.SelectedIndex = -1;
            ListBoxPatienten.Items.Clear();
            List<Patient> patienten = Patient.GetAll();
            foreach (Patient patient in patienten)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = patient.Voornaam + " " + patient.Achternaam;
                item.Tag = patient.Id;
                ListBoxPatienten.Items.Add(item);                
            }
        }

        private void ListBoxPatienten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // stel button states in
            ListBoxItem item = (ListBoxItem)ListBoxPatienten.SelectedItem;
            btnDeletePatient.IsEnabled = item != null;
            btnEditPatient.IsEnabled = item != null;
            btnInfoPatient.IsEnabled = item != null;
            if (item == null) return;

        }

        private void btnPatientZoeken_Click(object sender, RoutedEventArgs e)
        {
            ListBoxPatienten.SelectedIndex = -1;
            ListBoxPatienten.Items.Clear();
            List<Patient> patienten = Patient.GetAll();
            
            if (txtPatientZoeken.Text=="")
            {
                foreach (Patient patient in patienten)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = patient.Voornaam + " " + patient.Achternaam;
                    item.Tag = patient.Id;
                    ListBoxPatienten.Items.Add(item);
                }
            }
            else if (txtPatientZoeken.Text!="")
            {
                foreach (Patient patient in patienten)
                {
                    string naam = patient.Voornaam + " " + patient.Achternaam;
                    int lengte = txtPatientZoeken.Text.Length;
                    if (txtPatientZoeken.Text == naam.Substring(0, lengte))
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = patient.Voornaam + " " + patient.Achternaam;
                        item.Tag = patient.Id;
                        ListBoxPatienten.Items.Add(item);
                    }
                }
            }
        }
    }
}
