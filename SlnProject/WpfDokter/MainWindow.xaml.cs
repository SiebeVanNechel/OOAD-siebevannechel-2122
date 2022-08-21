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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        int loginId;
        public MainWindow(int id)
        {
            InitializeComponent();
            loginId = id;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxDagAfspraken.Items.Clear();
            lblAfsprakenVoor.Content = "Afspraken voor ";
            lblAfsprakenVoor.Content += Calendar.SelectedDate.Value.ToString("dddd dd MMMM yyyy");

            // vul listbox
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach (Afspraak afspraak in afspraken)
            {
                ListBoxItem item = new ListBoxItem();
                if (Calendar.SelectedDate.Value.ToString("dd/mm/yyyy") == afspraak.Moment.ToString("dd/mm/yyyy") && afspraak.DokterId == loginId)
                {
                    item.Content = afspraak.ToString();
                    item.Tag = afspraak.Id;
                    ListBoxDagAfspraken.Items.Add(item);
                }
            }
        }

        private void ListBoxDagAfspraken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxDagAfspraken.SelectedIndex!=-1)
            {
                ListBoxItem selectedItem = (ListBoxItem)ListBoxDagAfspraken.SelectedItem;
                lblRedenConsultatie.Content = Afspraak.FindById(Convert.ToInt32(selectedItem.Tag)).Klacht;
            }
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            PageOverzichtPatiënten page = new PageOverzichtPatiënten();
            frmMain.NavigationService.Navigate(page);
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            // vraag id geselecteerde afspraak op
            ListBoxItem item = (ListBoxItem)ListBoxDagAfspraken.SelectedItem;
            int afspraakid = Convert.ToInt32(item.Tag);
            Afspraak afspraak = Afspraak.FindById(afspraakid);

            // vraag bevestiging
            MessageBoxResult result = MessageBox.Show($"Ben je zeker dat je uw afspraak  op {afspraak.Moment.ToString("dd/MM/yyyy")} wil annuleren?", "Afspraak annuleren", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            if (afspraak.Moment < DateTime.Now)
            {
                MessageBox.Show("Men kan geen afspraken uit het verleden verwijderen");
                ListBoxDagAfspraken.SelectedIndex = -1;
            }
            else
            {
                // verwijder afspraak
                afspraak.DeleteFromDb();
            }

            // reload afspraken
            ListBoxDagAfspraken.SelectedIndex = -1;
            lblRedenConsultatie.Content = "";
            ListBoxDagAfspraken.Items.Clear();
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach (Afspraak afspraakReload in afspraken)
            {
                ListBoxItem itemReload = new ListBoxItem();
                if (loginId == afspraakReload.PatientId)
                {
                    itemReload.Content = (afspraakReload.Moment.ToString("dd/MM/yyyy") + " om " + afspraakReload.Moment.ToString("HH:mm"));
                    itemReload.Tag = afspraakReload.Id;
                    ListBoxDagAfspraken.Items.Add(itemReload);
                }
            }
        }
    }
}
