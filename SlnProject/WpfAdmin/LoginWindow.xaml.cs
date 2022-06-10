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
using MyClassLibrary;

namespace WpfAdmin
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
            List<User> users = User.GetAll();

            for (int i = 0; i < users.Count; i++)
            {
                if (txtLogin.Text == users[i].Login && txtPassword.Text==users[i].Password && users[i].Role=="admin")
                {
                    MainWindow mainWin = new MainWindow(users[i].Id);
                    mainWin.Show();
                    this.Close();
                }
            }
        }
    }
}
