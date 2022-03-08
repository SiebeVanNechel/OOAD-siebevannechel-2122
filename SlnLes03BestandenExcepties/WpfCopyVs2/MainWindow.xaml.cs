using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfCopyVs2
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
        List<string> lines = new List<string>();
        private void btnKiesPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            string chosenFileName;
            if (dialog.ShowDialog() == true)
            {
                // user picked a file and pressed OK
                chosenFileName = dialog.FileName;
                txtPath.Text = chosenFileName;
                lines = new List<string>();
                using(StreamReader reader = File.OpenText(chosenFileName))
                {
                    string line;
                    while ((line = reader.ReadLine())!= null) 
                    {
                        lines.Add(line);
                    }
                }
                btnGo.IsEnabled = true;
            }
            else
            {
                // user cancelled or escaped dialog window
                btnGo.IsEnabled = false;
                txtPath.Text = "";
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            dialog.FileName = "savedfile.txt";
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                using(StreamWriter writer = File.CreateText(path))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
                lblOut.Content = "Bestand is overgezet";
            }
            else
            {
                // user pressed Cancel or escaped dialog window
            }

        }
    }
}
