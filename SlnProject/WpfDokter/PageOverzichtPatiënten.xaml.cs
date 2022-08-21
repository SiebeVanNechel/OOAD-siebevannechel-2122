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
    /// Interaction logic for PageOverzichtPatiënten.xaml
    /// </summary>
    public partial class PageOverzichtPatiënten : Page
    {

        //int loginId;
        public PageOverzichtPatiënten()
        {
            InitializeComponent();
            //loginId = id;
        }

        private void btnInfoPatien_Click(object sender, RoutedEventArgs e)
        {
            PageInfoPatiënt page = new PageInfoPatiënt();
            this.NavigationService.Navigate(page);
        }

        private void btnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            PageEditPatiënt page = new PageEditPatiënt();
            this.NavigationService.Navigate(page);
        }

        private void btnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
             
        }
    }
}
