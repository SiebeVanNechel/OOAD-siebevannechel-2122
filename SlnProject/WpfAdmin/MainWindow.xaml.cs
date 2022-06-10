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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // connectiestring nodig om te connecteren met de databank
        string connString = ConfigurationManager.AppSettings["connStr"];
        int loginId;
        int selectedId;
        public MainWindow(int id)
        {
            InitializeComponent();
            loginId = id;
            ReloadUsers(null);
        }

        public void ReloadUsers(int? selectedId)
        {
            // wis lijst en labels
            lbxResults.Items.Clear();
            lblId.Content = "";
            lblAchternaam.Content = "";
            lblVoornaam.Content = "";
            lblRole.Content = "";
            lblCreatedate.Content = "";
            lblLogin.Content = "";

            // laad alle werknemers in
            List<User> users = User.GetAll();
            foreach(User user in users)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = user.ToString();
                item.Tag = user.Id;
                item.IsSelected = selectedId == user.Id;
                lbxResults.Items.Add(item);
            }
        }
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWin = new NewWindow();
            newWin.Show();
            this.Close();
        }

        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // stel button states in
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            btnEdit.IsEnabled = item != null;
            btnRemove.IsEnabled = item != null;
            if (item == null) return;

            //als user geselecteerd is...

            selectedId = Convert.ToInt32(item.Tag);
            User user = User.FindById(selectedId);
            lblId.Content = user.Id;
            lblAchternaam.Content = user.Lastname;
            lblVoornaam.Content = user.Firstname;
            lblRole.Content = user.Role;
            lblCreatedate.Content = user.CreateDate;
            lblLogin.Content = user.Login;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditWindow newWin = new EditWindow(selectedId);
            newWin.Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // vraag id geselecteerde werknemer
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            int userId = Convert.ToInt32(item.Tag);
            User user = User.FindById(userId);

            // bevestiging
            MessageBoxResult result = MessageBox.Show($"Ben je zeker dat je gebruiker #{userId} wil verwijderen?", "Gebruiker verwijderen", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            // verwijder
            user.DeleteFromDb();
            ReloadUsers(null);
        }
    }
}
