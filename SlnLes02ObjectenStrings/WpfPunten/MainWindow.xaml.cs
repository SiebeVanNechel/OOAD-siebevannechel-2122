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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPunten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string naam = txtNaam.Text;
            string punt = txtPunt.Text;
            ListBoxPunten.Items.Add($"{naam} - {punt}/100");

            naam = "";
            punt = "";
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPunt.Text != "" && txtNaam.Text != "")
            {
                btnToevoegen.IsEnabled = true;
            }
            if (txtPunt.Text == "" || txtNaam.Text == "")
            {
                btnToevoegen.IsEnabled = false;
            }
        }

        private void ListBoxPunten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxPunten.SelectedItem != null)
            {
                string[] geselecteerd= new string[2];
                geselecteerd = ListBoxPunten.SelectedItem.ToString().Split('-');
                txtNaam.Text = geselecteerd[0];
                txtPunt.Text = geselecteerd[1];
                btnVerwijder.IsEnabled = true;
            }
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            ListBoxPunten.Items.Remove(ListBoxPunten.SelectedItem);
            txtNaam.Text = "";
            txtPunt.Text = "";
        }
    }
}
