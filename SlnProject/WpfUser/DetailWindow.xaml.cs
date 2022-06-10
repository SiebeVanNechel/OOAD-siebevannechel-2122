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

namespace WpfUser
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        int petId;
        public DetailWindow(int Id)
        {
            InitializeComponent();
            petId = Id;
            load(petId);
        }

        public void load(int petid)
        {
            Pet pet = Pet.FindById(petid);
            lblId.Content = pet.Id;
            lblnaam.Content = pet.Name;
            lblremarkst.Content = pet.Remarks;
            lblSex.Content = pet.Sex;
            lblSize.Content = pet.Size;
            lblAge.Content = pet.Age;
            lblTypeName.Content = pet.TypeName;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
