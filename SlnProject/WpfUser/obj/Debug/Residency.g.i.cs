// Updated by XamlIntelliSenseFileGenerator 10/06/2022 22:10:12
#pragma checksum "..\..\Residency.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "06295AC138BE23DDBA37CE32D845FF4FE87639C61E2F69AE44D21C7659DBE4CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfUser;


namespace WpfUser
{


    /// <summary>
    /// Residency
    /// </summary>
    public partial class Residency : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 12 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnResidencyHistory;

#line default
#line hidden


#line 30 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblId;

#line default
#line hidden


#line 32 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAchternaam;

#line default
#line hidden


#line 34 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblVoornaam;

#line default
#line hidden


#line 36 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRole;

#line default
#line hidden


#line 38 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCreatedate;

#line default
#line hidden


#line 40 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblLogin;

#line default
#line hidden


#line 42 "..\..\Residency.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxResults;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfUser;component/residency.xaml", System.UriKind.Relative);

#line 1 "..\..\Residency.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btnResidencyHistory = ((System.Windows.Controls.Button)(target));

#line 12 "..\..\Residency.xaml"
                    this.btnResidencyHistory.Click += new System.Windows.RoutedEventHandler(this.btnNewPet_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btnResidency = ((System.Windows.Controls.Button)(target));
                    return;
                case 3:
                    this.lblId = ((System.Windows.Controls.Label)(target));
                    return;
                case 4:
                    this.lblAchternaam = ((System.Windows.Controls.Label)(target));
                    return;
                case 5:
                    this.lblVoornaam = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.lblRole = ((System.Windows.Controls.Label)(target));
                    return;
                case 7:
                    this.lblCreatedate = ((System.Windows.Controls.Label)(target));
                    return;
                case 8:
                    this.lblLogin = ((System.Windows.Controls.Label)(target));
                    return;
                case 9:
                    this.lbxResults = ((System.Windows.Controls.ListBox)(target));

#line 42 "..\..\Residency.xaml"
                    this.lbxResults.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxResults_SelectionChanged);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

