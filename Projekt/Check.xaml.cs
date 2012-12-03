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
    public partial class Check : PhoneApplicationPage
    {
        App thisApp = Application.Current as App;
        public Check()
        {
            InitializeComponent();
            int q_num = thisApp.game.getQnum();
            q_number.Text = "QUESTION " + q_num.ToString() + " / 8";
            q_content.Text = thisApp.game.questions[q_num].getQuestionContent();

            correct_answer.Text = thisApp.game.questions[q_num].getCorrectAnswer();


            thisApp.game.Cash = (thisApp.game.getBets(thisApp.game.questions[q_num].getCorrectAnswerNum()));
            remaining_cash.Text = remaining_cash.Text + thisApp.game.Cash.ToString();

            if (thisApp.game.Cash > 0)
            {
                if (q_num == 8)
                {
                    info.Text = "Congratulations, " + thisApp.setData.Nick + "! You survive eight questions and win your cash!";
                    Next_Q.Visibility = Visibility.Collapsed;
                }
                else
                {
                    info.Text = "Congratulations, " + thisApp.setData.Nick + "! You are still in a game!";
                    GoToMenu.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                info.Text = "Unfortunantely, " + thisApp.setData.Nick + ". You lose.";
                Next_Q.Visibility = Visibility.Collapsed;
            }
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit game? You will lose your progres.", "Exit page notification", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            { e.Cancel = true; }
            else { NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute)); }
        }

        private void Next_Q_Click(object sender, RoutedEventArgs e)
        {
            thisApp.game.incQnum();
            int q_num = thisApp.game.getQnum();
            if (q_num < 5)
            {
                NavigationService.Navigate(new Uri("/StageOne.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (q_num < 8)
            {
                NavigationService.Navigate(new Uri("/StageTwo.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (q_num < 9)
            {
                NavigationService.Navigate(new Uri("/FinalStage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void GoToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}