using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using DokterspraktijkClassLibrary;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace WpfDokter
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            lblFoutmelding.Content = "";
            List<Dokter> Dokters = Dokter.GetAll();
            for (int i = 0; i < Dokters.Count; i++)
            {
                //MessageBox.Show(HashPassword(txtPassword.Text));
                if (txtEmail.Text == Dokters[i].Email && HashPassword(txtPassword.Text).ToLower() == Dokters[i].Paswoord)
                {
                    MainWindow mainWin = new MainWindow(Dokters[i].Id);
                    mainWin.Show();
                    this.Close();
                }
                else if (txtEmail.Text == Dokters[i].Email && HashPassword(txtPassword.Text).ToLower() != Dokters[i].Paswoord)
                {
                    lblFoutmelding.Content = "Onjuist paswoord";
                }
                else if (txtEmail.Text != Dokters[i].Email && HashPassword(txtPassword.Text).ToLower() == Dokters[i].Paswoord)
                {
                    lblFoutmelding.Content = "Onjuist mailadres";
                }
                else if (txtEmail.Text != Dokters[i].Email && HashPassword(txtPassword.Text).ToLower() != Dokters[i].Paswoord)
                {
                    lblFoutmelding.Content = "Onjuist mailadres en paswoord";
                }
            }
        }

        protected static string HashPassword(string pw)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] pwBytes = Encoding.UTF8.GetBytes(pw);
            byte[] pwHashed = sha256.ComputeHash(pwBytes);
            return BitConverter.ToString(pwHashed).Replace("-", String.Empty);
        }
    }
}
