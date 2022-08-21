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

namespace WpfDokter
{
    /// <summary>
    /// Interaction logic for PageInfoPatiënt.xaml
    /// </summary>
    public partial class PageInfoPatiënt : Page
    {
        public PageInfoPatiënt()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            PageOverzichtPatiënten page = new PageOverzichtPatiënten();
            this.NavigationService.Navigate(page);
        }
    }
}
