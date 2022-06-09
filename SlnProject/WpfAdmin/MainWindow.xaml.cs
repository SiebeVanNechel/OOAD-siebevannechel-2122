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

namespace WpfAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // connectiestring nodig om te connecteren met de databank
        string connString = ConfigurationManager.AppSettings["connString"];
        int loginId;
        public MainWindow(int id)
        {
            InitializeComponent();
            loginId = id;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWin = new NewWindow(loginId);
            newWin.Show();
        }
    }
}
