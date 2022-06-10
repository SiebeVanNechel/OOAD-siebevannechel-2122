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
using System.Windows.Shapes;
using MyClassLibrary;

namespace WpfAdmin
{
    /// <summary>
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        string connString = ConfigurationManager.AppSettings["connStr"];

        public NewWindow()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string firstname = txtFirst.Text;
            string lastname = txtLast.Text;
            string role = txtRole.Text;
            DateTime createdate = DateTime.Now;
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            User user = new User(0, login, password, firstname, lastname, createdate, role);
            int newId = user.InsertToDb();

            //herlaad hoofdvenster
            MainWindow mainWin = new MainWindow(user.Id);
            mainWin.Show();
            mainWin.ReloadUsers(user.Id);
            this.Close();
        }
    }
}
