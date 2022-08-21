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

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for PageOverzichtAfspraken.xaml
    /// </summary>
    public partial class PageOverzichtAfspraken : Page
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        int loginId;
       public PageOverzichtAfspraken(int id)
        {
            InitializeComponent();
            loginId = id;
        }

        private void btnNieuweAfspraak_Click(object sender, RoutedEventArgs e)
        {
            PageAfspraakMaken page = new PageAfspraakMaken(loginId);
            this.NavigationService.Navigate(page);
        }

        private void RadioAlleAfspraken_Checked(object sender, RoutedEventArgs e)
        {
            ListBoxAfspraken.SelectedIndex = -1;
            lblRedenConsultatie.Text = "";
            ListBoxAfspraken.Items.Clear();
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach(Afspraak afspraak in afspraken)
            {
                ListBoxItem item = new ListBoxItem();
                if (loginId==afspraak.PatientId)
                {
                    item.Content = (afspraak.Moment.ToString("dd/MM/yyyy") + " om " + afspraak.Moment.ToString("HH:mm"));
                    item.Tag = afspraak.Id;
                    ListBoxAfspraken.Items.Add(item);
                }
            }
        }

        private void RadioToekomstigeAfspraken_Checked(object sender, RoutedEventArgs e)
        {
            ListBoxAfspraken.SelectedIndex = -1;
            lblRedenConsultatie.Text = "";
            ListBoxAfspraken.Items.Clear();
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach (Afspraak afspraak in afspraken)
            {
                ListBoxItem item = new ListBoxItem();
                if (loginId==afspraak.PatientId && afspraak.Moment > DateTime.Now)
                {
                    item.Content = (afspraak.Moment.ToString("dd/MM/yyyy") + " om " + afspraak.Moment.ToString("HH:mm"));
                    item.Tag = afspraak.Id;
                    ListBoxAfspraken.Items.Add(item);
                }
            }
        }

        private void ListBoxAfspraken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)ListBoxAfspraken.SelectedItem;
            if (selectedItem!=null)
            {
                lblRedenConsultatie.Text = Afspraak.FindById(Convert.ToInt32(selectedItem.Tag)).Klacht;
            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            // vraag id geselecteerde werknemer op
            ListBoxItem item = (ListBoxItem)ListBoxAfspraken.SelectedItem;
            int afspraakid = Convert.ToInt32(item.Tag);
            Afspraak afspraak = Afspraak.FindById(afspraakid);

            // vraag bevestiging
            MessageBoxResult result = MessageBox.Show($"Ben je zeker dat je uw afspraak  op {afspraak.Moment.ToString("dd/MM/yyyy")} wil annuleren?", "Afspraak annuleren", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            if (afspraak.Moment < DateTime.Now)
            {
                MessageBox.Show("Men kan geen afspraken uit het verleden verwijderen");
                ListBoxAfspraken.SelectedIndex = -1;
            }
            else
            {
                // verwijder werknemer
                afspraak.DeleteFromDb();
            }

            // reload afspraken
            ListBoxAfspraken.SelectedIndex = -1;
            lblRedenConsultatie.Text = "";
            ListBoxAfspraken.Items.Clear();
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach (Afspraak afspraakReload in afspraken)
            {
                ListBoxItem itemReload = new ListBoxItem();
                if (loginId == afspraakReload.PatientId)
                {
                    itemReload.Content = (afspraakReload.Moment.ToString("dd/MM/yyyy") + " om " + afspraakReload.Moment.ToString("HH:mm"));
                    itemReload.Tag = afspraakReload.Id;
                    ListBoxAfspraken.Items.Add(itemReload);
                }
            }
        }
    }
}
