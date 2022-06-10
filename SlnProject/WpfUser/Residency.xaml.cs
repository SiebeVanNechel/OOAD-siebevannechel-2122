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
    /// Interaction logic for Residency.xaml
    /// </summary>
    public partial class Residency : Window
    {
        int loginId;
        public Residency(int id)
        {
            InitializeComponent();
            loginId = id;
        }

        public void ReloadUsers(int? selectedId)
        {
            // wis lijst en labels
            lbxResults.Items.Clear();
            lblId.Content = "";
            lblStartDate.Content = "";
            lblEndDate.Content = "";
            lblRemarks.Content = "";

            // laad alle werknemers in
           /* List<Residency> residenys = Residency.GetResidency(loginId);
            foreach (Residency residency in residenys)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = residency.ToString();
                item.Tag = residency.id;
                item.IsSelected = selectedId == residency.Id;
                lbxResults.Items.Add(item);
            }*/
        }
    }
}
