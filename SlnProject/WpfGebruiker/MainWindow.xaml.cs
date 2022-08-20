using DokterspraktijkClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.IO;

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connString = ConfigurationManager.AppSettings["connStr"];
        public int loginId;

        //Patient patient;
        public MainWindow(int id)
        {
            InitializeComponent();
            loginId = id;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // vul gegevens
            Patient patient = Patient.FindById(loginId);
            lblVoornaam.Content = patient.Voornaam;
            lblAchternaam.Content = patient.Achternaam;
            lblGeslacht.Content = patient.Geslacht;
            lblGeboortedatum.Content = patient.Geboortedatum.ToString("dd/MM/yyyy");
            txtEmail.Text = patient.Email;
            txtGsm.Text = patient.Gsm.ToString();
            ImgFotoUser.Source = patient.Profielfotodata == null ? new BitmapImage(new Uri("Img/DefaultAvatar.png", UriKind.Relative)) : patient.Profielfotodata;
            ComboBoxHerinnering.Text = patient.Notificaties.ToString();
        }

        private void btnVoorkeurenOpslaan_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
