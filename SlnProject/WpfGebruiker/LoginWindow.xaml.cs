using DokterspraktijkClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


namespace WpfGebruiker
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
            List<Patient> Patienten = Patient.GetAll();

            for (int i = 0; i < Patienten.Count; i++)
            {
                //MessageBox.Show(HashPassword(txtPassword.Text));
                if (txtEmail.Text == Patienten[i].Email && HashPassword(txtPassword.Text).ToLower() == Patienten[i].Paswoord)
                {
                    MainWindow mainWin = new MainWindow(Patienten[i].Id);
                    mainWin.Show();
                    this.Close();
                }
                else if (txtEmail.Text == Patienten[i].Email && HashPassword(txtPassword.Text).ToLower() != Patienten[i].Paswoord)
                {
                    lblFoutmelding.Content = "Onjuist paswoord";
                }
                else if (txtEmail.Text != Patienten[i].Email && HashPassword(txtPassword.Text).ToLower() == Patienten[i].Paswoord)
                {
                    lblFoutmelding.Content = "Onjuist mailadres";
                }
                else if (txtEmail.Text != Patienten[i].Email && HashPassword(txtPassword.Text).ToLower() != Patienten[i].Paswoord)
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
