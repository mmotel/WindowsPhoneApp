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
    public partial class MainPage : PhoneApplicationPage
    {
        App thisApp = Application.Current as App;
        public MainPage()
        {
            InitializeComponent();
            //thisApp.setData.loadSettings();        
        }

        
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit game?", "Exit page notification", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            { e.Cancel = true; }
            else
            {
                if (NavigationService.CanGoBack)
                {
                    while (NavigationService.RemoveBackEntry() != null)
                    {
                        NavigationService.RemoveBackEntry();
                    }
                }
            }
        }

        private void Stage1_Click(object sender, RoutedEventArgs e)
        {
            thisApp.game = new Game();
            thisApp.game.resetGame();
            NavigationService.Navigate(new Uri("/StageOne.xaml", UriKind.RelativeOrAbsolute));
        }
/*
        private void Stage2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/StageTwo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Stage3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FinalStage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Check.xaml", UriKind.RelativeOrAbsolute));
        }
        */
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void testuj_Click(object sender, RoutedEventArgs e)
        {
            thisApp.setData.clearIS("settings.txt");
            test.Text = "";
            thisApp.setData.loadSettings();
        }
    }
}