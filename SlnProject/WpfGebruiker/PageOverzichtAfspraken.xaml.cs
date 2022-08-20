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
       public PageOverzichtAfspraken()
        {
            InitializeComponent();
            
        }

        private void btnNieuweAfspraak_Click(object sender, RoutedEventArgs e)
        {
            PageAfspraakMaken page = new PageAfspraakMaken();
            this.NavigationService.Navigate(page);
        }

        private void RadioAlleAfspraken_Checked(object sender, RoutedEventArgs e)
        {
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach(Afspraak afspraak in afspraken)
            {
               //if (window.loginId==afspraak.PatientId)
                //{
                ListBoxAfspraken.Items.Add(afspraak.Moment.ToString("dd/MM/yyyy") + " om " + afspraak.Moment.ToString("HH:mm"));
                //}
            }
        }

        private void RadioToekomstigeAfspraken_Checked(object sender, RoutedEventArgs e)
        {
            List<Afspraak> afspraken = Afspraak.GetAll();
            foreach (Afspraak afspraak in afspraken)
            {
                /*if (MainWindow.loginid==afspraak.PatientId)
                {
                    ListBoxAfspraken.Items.Add(afspraak.Moment.ToString("dd/MM/yyyy") + " om " + afspraak.Moment.ToString("HH:mm"));
                }*/
            }
        }
    }
}
