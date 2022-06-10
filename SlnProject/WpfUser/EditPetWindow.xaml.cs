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
using WpfAdmin;

namespace WpfUser
{
    /// <summary>
    /// Interaction logic for EditPetWindow.xaml
    /// </summary>
    public partial class EditPetWindow : Window
    {
        // connecteren met databank
        string connString = ConfigurationManager.AppSettings["connStr"];

        int petid;
        int loginid;
        // referentie naar hoofdvenster
        Pet pet;
        public EditPetWindow(int id, int useId)
        {
            InitializeComponent();
            petid = id;
            loginid = useId;
            
            this.Title = $"Pet #{id} bewerken";
            pet = Pet.FindById(id);
            txtNaam.Text = pet.Name;
            txtRemarks.Text = pet.Remarks;
            if (pet.Sex == 1) txtSex.Text = "M";
            if (pet.Sex == 2) txtSex.Text = "V";
            txtSize.Text = pet.Size.ToString();
            txtAge.Text = pet.Age.ToString();
            txtTypeName.Text = pet.TypeName;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow(loginid);
            mainWin.Show();
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // user opslaan
            using (SqlConnection conn = new SqlConnection(connString)) ;
            {
                pet.Name = txtNaam.Text;
                pet.Remarks = txtRemarks.Text;
                if (pet.Sex==1) txtSex.Text = "M";
                if (pet.Sex == 2) txtSex.Text = "V";
                pet.Size = int.Parse(txtSize.Text);
                pet.Age = int.Parse(txtAge.Text);
                pet.TypeName = txtTypeName.Text;
                pet.UpdateInDb();
            }

            // herlaad hoofdvenster
            MainWindow mainWin = new MainWindow(pet.Id);
            mainWin.Show();
            mainWin.ReloadPet(loginid);
            this.Close();
        }
    }
}
