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

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for PageAfspraakMaken.xaml
    /// </summary>
    public partial class PageAfspraakMaken : Page
    {
        public PageAfspraakMaken()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            PageOverzichtAfspraken page = new PageOverzichtAfspraken();
            this.NavigationService.Navigate(page);
        }
    }
}
