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

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Instruction.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Ranking_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Ranking.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}