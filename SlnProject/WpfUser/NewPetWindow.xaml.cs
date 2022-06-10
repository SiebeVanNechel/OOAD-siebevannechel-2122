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
using WpfAdmin;
using MyClassLibrary;

namespace WpfUser
{
    /// <summary>
    /// Interaction logic for NewPetWindow.xaml
    /// </summary>
    public partial class NewPetWindow : Window
    {
        int loginId;
        public NewPetWindow(int id)
        {
            InitializeComponent();
            loginId = id;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string naam = txtNaam.Text;
            string remark = txtRemarks.Text;
            int geslacht=0;
            if (ComboSex.Text=="M") geslacht = 1;
            if (ComboSex.Text == "V") geslacht = 2;
            int size = int.Parse(txtSize.Text);
            int age = int.Parse(txtAge.Text);
            string type = txtTypeName.Text;
            int userid = loginId;
            Pet pet = new Pet(naam, remark, geslacht, size, age, userid, type);
            int newId = pet.InsertToDb();

            //herlaad hoofdvenster
            MainWindow mainWin = new MainWindow(loginId);
            mainWin.Show();
            this.Close();
        }
    }
}
