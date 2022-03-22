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

namespace WpfNotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath = "";
        private string initialfolderPath;
        public MainWindow()
        {
            InitializeComponent();
            initialfolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow view = new AboutWindow();
            view.Show();
        }

        private void txtInput_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtInput.SelectionLength>0)
            {
                btnCopy.IsEnabled = true;
                btnCut.IsEnabled = true;
                btnPaste.IsEnabled = false;
            }
            else
            {
                btnCopy.IsEnabled = false;
                btnCut.IsEnabled = false;
                btnPaste.IsEnabled = false;
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtInput.SelectedText);
            btnPaste.IsEnabled = true;
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtInput.SelectedText);
            txtInput.Text = "";
            btnPaste.IsEnabled = true;
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Paste();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblChars.Content = "#chars: " + txtInput.Text.Length.ToString();

            if (txtInput.Text == "")
            {
                btnSave.IsEnabled = false;
                btnSaveAs.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
                btnSaveAs.IsEnabled = true;
            }
        }

        private void btnOpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StreamReader reader;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = initialfolderPath;
            if (dialog.ShowDialog() == true)
            {
                currentFilePath = dialog.FileName;
                reader = File.OpenText(currentFilePath);
                txtInput.Text = reader.ReadToEnd();
                Tabheader.Header = new DirectoryInfo(dialog.SafeFileName).ToString();
                reader.Close();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentFilePath=="")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = initialfolderPath;
                if (dialog.ShowDialog()==true)
                {
                    currentFilePath = dialog.FileName;
                }
                Tabheader.Header = new DirectoryInfo(dialog.SafeFileName).ToString();
            }
            StreamWriter writer = File.CreateText(currentFilePath);
            writer.Write(txtInput.Text);
            writer.Close();
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialfolderPath;
            if (dialog.ShowDialog() ==  true)
            {
                currentFilePath = dialog.FileName;
                writer = File.CreateText(currentFilePath);
                writer.Write(txtInput.Text);
                Tabheader.Header = new DirectoryInfo(dialog.SafeFileName).ToString();
                writer.Close();
            }
        }

        private void btnExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
