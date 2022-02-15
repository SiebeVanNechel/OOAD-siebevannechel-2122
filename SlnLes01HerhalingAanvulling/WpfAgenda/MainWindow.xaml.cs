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

namespace WpfAgenda
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
            lblFoutTitel.Visibility = Visibility.Hidden;
            lblFoutDatum.Visibility = Visibility.Hidden;
            lblFoutType.Visibility = Visibility.Hidden;
            lblFoutHerinnering.Visibility = Visibility.Hidden;
            lblFoutMelding.Visibility = Visibility.Hidden;
            lblAantalFouten.Content = "";
            int aantalfouten = 0;

            if (txbTitel.Text=="")
            {
                lblFoutTitel.Visibility = Visibility.Visible;
                aantalfouten++;
            }
            if (DatePickerDatum.SelectedDate==null)
            {
                lblFoutDatum.Visibility = Visibility.Visible;
                aantalfouten++;
            }
            if(cmbType.SelectedItem==null)
            {
                lblFoutType.Visibility = Visibility.Visible;
                aantalfouten++;
            }
            if (RadioGeen.IsChecked==false && Radio1Dag.IsChecked==false && Radio2Dag.IsChecked==false && Radio3Dag.IsChecked==false)
            {
                lblFoutHerinnering.Visibility = Visibility.Visible;
                aantalfouten++;
            }
            if (CheckNotificatie.IsChecked==false && CheckEmail.IsChecked==false)
            {
                lblFoutMelding.Visibility = Visibility.Visible;
                aantalfouten++;
            }
            else
            {
                ListBoxItem afspraak = new ListBoxItem();
                afspraak.Content = DatePickerDatum.SelectedDate.Value.ToString("dd//mm/yyyy") + " - " + txbTitel.Text;
                ListBoxAfspraken.Items.Add(afspraak);

                //invoer leegmaken
                txbTitel.Text = "";
                cmbType.SelectedIndex = -1;
                Radio1Dag.IsChecked = false;
                Radio2Dag.IsChecked = false;
                Radio3Dag.IsChecked = false;
                RadioGeen.IsChecked = false;
                CheckEmail.IsChecked = false;
                CheckNotificatie.IsChecked = false;
                lblAantalFouten.Visibility = Visibility.Hidden;
            }

            if (aantalfouten==1)
            {
                lblAantalFouten.Content = $"Het formulier bevat {aantalfouten} fout";
            }
            else
            {
                lblAantalFouten.Content = $"Het formulier bevat {aantalfouten} fouten";
            }
        }
    }
}
