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
using System.Windows.Shapes;
using MyClassLibrary;

namespace WpfAdmin
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        // connecteren met databank
        string connString = ConfigurationManager.AppSettings["connStr"];

        // referentie naar hoofdvenster en userid
        User user;
        public EditWindow(int id)
        {
            InitializeComponent();
            this.Title = $"User #{id} bewerken";
            user = User.FindById(id);
            txtFirst.Text = user.Firstname;
            txtLast.Text = user.Lastname;
            txtRole.Text = user.Role;
            txtLogin.Text = user.Login;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // user opslaan
            using (SqlConnection conn = new SqlConnection(connString));
            {
                user.Firstname = txtFirst.Text;
                user.Lastname = txtLast.Text;
                user.Role = txtRole.Text;
                user.CreateDate= DateTime.Now;
                user.Login = txtLogin.Text;
                user.Password = txtPassword.Text;
                user.UpdateInDb();
            }

            // herlaad hoofdvenster
            MainWindow mainWin = new MainWindow(user.Id);
            mainWin.Show();
            mainWin.ReloadUsers(user.Id);
            this.Close();
        }
    }
}
