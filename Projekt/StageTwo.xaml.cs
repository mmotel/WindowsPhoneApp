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
    public partial class StageTwo : PhoneApplicationPage
    {
        App thisApp = Application.Current as App;
        StagesData tmpData = new StagesData();
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        // A variable to count with.
        int i;

        public StageTwo()
        {
            InitializeComponent();        
            LayoutRoot.DataContext = tmpData;
            i = thisApp.setData.Level;

            int q_num = thisApp.game.getQnum();

            q_number.Text = "QUESTION " + q_num.ToString() + " / 8";
            q_content.Text = thisApp.game.questions[q_num].getQuestionContent();
            txtblock.Text = "Time: " + i.ToString();

            Answer1_text.Text = thisApp.game.questions[q_num].getQuestionAnswer(1);
            Answer2_text.Text = thisApp.game.questions[q_num].getQuestionAnswer(2);
            Answer3_text.Text = thisApp.game.questions[q_num].getQuestionAnswer(3);
            
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myDispatcherTimer.Stop();
            if (MessageBox.Show("Do you really want to exit game? You will lose your progres.", "Exit page notification", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            { e.Cancel = true; myDispatcherTimer.Start(); }
            else { NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute)); }
        }


        public void StartTimer(object o, RoutedEventArgs sender)
        {

            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 1000 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            myDispatcherTimer.Start();
        }


        // Raised every 1000 miliseconds while the DispatcherTimer is active.
        public void Each_Tick(object o, EventArgs sender)
        {
            if (i == 0)
            {
                myDispatcherTimer.Stop();
                txtblock.Text = "Time: " + i.ToString();
                CheckAnswer();
            }
            else if(i > 0)
            {
                i--;
                passingTime.Width -= 230 / thisApp.setData.Level; 
                txtblock.Text = "Time: " + i.ToString();
            }
        }

        private void CheckAnswer()
        {
            if (tmpData.Rem_cash > 0)
            {
                MessageBox.Show("You have to bet all your cash! Remaining cash will be lost.", "Chech answer error.", MessageBoxButton.OK);
                tmpData.Rem_cash = 0;
                Cash.Text = tmpData.Rem_cash.ToString();
            }
            else if (tmpData.Bet1 > 0 && tmpData.Bet2 > 0 && tmpData.Bet3 > 0)
            {
                MessageBox.Show("You can bet only on two answers! Lowest bet will be lost.", "Chech answer error.", MessageBoxButton.OK);
                int low_bet = 1;
                for (int j = 2; j < 4; j++)
                {
                    if (tmpData.getBets(j) < tmpData.getBets(j - 1))
                    {
                        low_bet = j;
                    }
                }
                tmpData.setBets(low_bet, 0); 
            }

            thisApp.game.saveData(tmpData.Bet1, tmpData.Bet2, tmpData.Bet3, tmpData.Bet4);
            NavigationService.Navigate(new Uri("/Check.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            myDispatcherTimer.Stop();
            CheckAnswer();
        }
    }
}