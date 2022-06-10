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
using WpfUser;

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
        int selectedPetId;
        public MainWindow(int id)
        {
            InitializeComponent();
            loginId = id;
            ReloadPet(loginId);
        }

        public void ReloadPet(int loginId)
        {
            // wis labels
            lbxResults.Items.Clear();
            lblId.Content = "";
            lblAchternaam.Content = "";
            lblVoornaam.Content = "";
            lblRole.Content = "";
            lblCreatedate.Content = "";
            lblLogin.Content = "";

            // vul labels
            User user = User.FindById(loginId);
            lblId.Content = user.Id;
            lblAchternaam.Content = user.Lastname;
            lblVoornaam.Content = user.Firstname;
            lblRole.Content = user.Role;
            lblCreatedate.Content = user.CreateDate;
            lblLogin.Content = user.Login;

            // vul listbox
            List<Pet> pets = Pet.GetPets(loginId);
            foreach (Pet pet in pets)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = pet.ToString();
                item.Tag = pet.Id;
                item.IsSelected = loginId == pet.Id;
                lbxResults.Items.Add(item);
            }
        }

        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // stel button states in
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            btnDetails.IsEnabled = item != null;
            btnEditPet.IsEnabled = item != null;
            btnRemovePet.IsEnabled = item != null;
            if (item == null) return;

            //als user geselecteerd is...
            selectedPetId = Convert.ToInt32(item.Tag);/*
            User user = User.FindById(selectedId);
            lblId.Content = user.Id;
            lblAchternaam.Content = user.Lastname;
            lblVoornaam.Content = user.Firstname;
            lblRole.Content = user.Role;
            lblCreatedate.Content = user.CreateDate;
            lblLogin.Content = user.Login;
            */
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow newWin = new DetailWindow(selectedPetId);
            newWin.Show();
        }

        private void btnNewPet_Click(object sender, RoutedEventArgs e)
        {
            NewPetWindow newWin = new NewPetWindow(loginId);
            newWin.Show();
            this.Close();
        }

        private void btnRemovePet_Click(object sender, RoutedEventArgs e)
        {
            // vraag id geselecteerde werknemer
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            int petId = Convert.ToInt32(item.Tag);
            Pet pet = Pet.FindById(petId);

            // bevestiging
            MessageBoxResult result = MessageBox.Show($"Ben je zeker dat je huisdier #{petId} wil verwijderen?", "Gebruiker verwijderen", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            // verwijder
            pet.DeleteFromDb();
            ReloadPet(loginId);
        }

        private void btnEditPet_Click(object sender, RoutedEventArgs e)
        {
            EditPetWindow newWin = new EditPetWindow(selectedPetId, loginId);
            newWin.Show();
            this.Close();
        }
    }
}
