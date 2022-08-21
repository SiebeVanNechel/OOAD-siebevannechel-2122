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
                if (Calendar.SelectedDate.Value.ToString("dd/mm/yyyy")==afspraak.Moment.ToString("dd/mm/yyyy") && afspraak.DokterId == loginId)
                {
                    item.Content = afspraak.ToString();
                    item.Tag = afspraak.Id;
                    ListBoxDagAfspraken.Items.Add(item);
                }
            }
        }

        private void ListBoxDagAfspraken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)ListBoxDagAfspraken.SelectedItem;
            lblRedenConsultatie.Content = Afspraak.FindById(Convert.ToInt32(selectedItem.Tag)).Klacht;
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            PageOverzichtPatiënten page = new PageOverzichtPatiënten();
            frmMain.NavigationService.Navigate(page);
        }
    }
}
