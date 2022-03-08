using Microsoft.Win32;
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
using System.IO;

namespace WpfFileInfo
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

        private void btnKiesBestand_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            string chosenFileName;
            if (dialog.ShowDialog() == true)
            {
                chosenFileName = dialog.FileName;
                lblBestandsnaam.Content += System.IO.Path.GetFileName(chosenFileName);
                lblExtentie.Content += System.IO.Path.GetExtension(chosenFileName);
                lbldatum.Content += File.GetCreationTime(chosenFileName).ToString();

                string fullPath = System.IO.Path.GetDirectoryName(chosenFileName);
                string[] folders = fullPath.Split('\\');
                //MessageBox.Show(folders.Length.ToString());
                string folder = folders[folders.Length - 1];
                lblMapnaam.Content += folder;
            }
        }
    }
}
