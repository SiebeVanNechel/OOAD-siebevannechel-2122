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

namespace WpfOxo
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
        int i = 0;
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            i++;
            if (i % 2 == 0)
            {
                btn.Content = "X";
            }
            else
            {
                btn.Content = "O";
            }

            if (btn1.Content == "X" && btn2.Content == "X" && btn3.Content == "X" || btn4.Content == "X" && btn5.Content == "X" && btn6.Content == "X" || btn7.Content == "X" && btn8.Content == "X" && btn9.Content == "X" ||
                btn1.Content == "X" && btn4.Content == "X" && btn7.Content == "X" || btn2.Content == "X" && btn5.Content == "X" && btn8.Content == "X" || btn3.Content == "X" && btn6.Content == "X" && btn9.Content == "X"
                || btn1.Content == "X" && btn5.Content == "X" && btn9.Content == "X" || btn3.Content == "X" && btn5.Content == "X" && btn7.Content == "X")
            {
                MessageBox.Show("X heeft gewonnen");
            }

            if (btn1.Content == "O" && btn2.Content == "O" && btn3.Content == "O" || btn4.Content == "O" && btn5.Content == "O" && btn6.Content == "O" || btn7.Content == "O" && btn8.Content == "O" && btn9.Content == "O" ||
                btn1.Content == "O" && btn4.Content == "O" && btn7.Content == "O" || btn2.Content == "O" && btn5.Content == "O" && btn8.Content == "O" || btn3.Content == "O" && btn6.Content == "O" && btn9.Content == "O"
                || btn1.Content == "O" && btn5.Content == "O" && btn9.Content == "O" || btn3.Content == "O" && btn5.Content == "O" && btn7.Content == "O")
            {
                MessageBox.Show("O heeft gewonnen");
            }
        }
    }
}
