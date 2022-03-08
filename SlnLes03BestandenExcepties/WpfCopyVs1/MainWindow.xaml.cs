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

namespace WpfCopyVs1
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

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            string FileIn = txtFileIn.Text;
            string FileOut = txtFileOut.Text;

            //inlezen
            // prepare
            string[] lines;
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(folderPath, FileIn);

            // read all lines at once
            lines = File.ReadAllLines(filePath);

            //schrijven
            // prepare
            List<string> linesSchrijven = new List<string>();
            string folderPathSchrijven = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePathSchrijven = System.IO.Path.Combine(folderPathSchrijven, FileOut);

            // open stream and start writing
            using (StreamWriter writer = File.CreateText(filePathSchrijven))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            } // stream closes automatically
            lblBevestiging.Content = "Bestand is overgezet";
        }
    }
}
