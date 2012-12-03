using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Projekt
{
    public partial class Settings : PhoneApplicationPage
    {
        App thisApp = Application.Current as App;
        public Settings()
        {
            InitializeComponent();
            LayoutRoot.DataContext = thisApp.setData;
            
            Categories_Checking();
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            Categories_Checking();
        }

        private void Categories_Checking(){
             int n =0;

             if (thisApp.setData.Cat1 == true) { n++; }
             if (thisApp.setData.Cat2 == true) { n++; }
             if (thisApp.setData.Cat3 == true) { n++; }
             if (thisApp.setData.Cat4 == true) { n++; }
             if (thisApp.setData.Cat5 == true) { n++; }
             if (thisApp.setData.Cat6 == true) { n++; }

             if (n >= 2)
             {
                 if (thisApp.setData.Cat1 == false) { cat1.IsEnabled = false; }
                 if (thisApp.setData.Cat2 == false) { cat2.IsEnabled = false; }
                 if (thisApp.setData.Cat3 == false) { cat3.IsEnabled = false; }
                 if (thisApp.setData.Cat4 == false) { cat4.IsEnabled = false; }
                 if (thisApp.setData.Cat5 == false) { cat5.IsEnabled = false; }
                 if (thisApp.setData.Cat6 == false) { cat6.IsEnabled = false; }
             }
             else
             {
                 cat1.IsEnabled = true;
                 cat2.IsEnabled = true;
                 cat3.IsEnabled = true;
                 cat4.IsEnabled = true;
                 cat5.IsEnabled = true;
                 cat6.IsEnabled = true;
             }
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            thisApp.setData.saveSettings();
        }
    }
}