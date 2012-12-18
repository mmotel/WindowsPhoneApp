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
    public partial class Ranking : PhoneApplicationPage
    {
        App thisApp = Application.Current as App;

        public Ranking()
        {
            InitializeComponent();

            List<Storage> rank = thisApp.ActiveDB.getScores();
            Storage[] ArrayRank = rank.ToArray();

            try
            {
                one_nick.Text = "1. " + ArrayRank[0].Nick;
                one_score.Text = "Result: " + ArrayRank[0].Score.ToString();
                one_date.Text = "Date: " + ArrayRank[0].Date.ToString();
                no1.Visibility = Visibility.Visible;

                two_nick.Text = "2. " + ArrayRank[1].Nick;
                two_score.Text = "Result: " + ArrayRank[1].Score.ToString();
                two_date.Text = "Date: " + ArrayRank[1].Date.ToString();
                no2.Visibility = Visibility.Visible;

                three_nick.Text = "3. " + ArrayRank[2].Nick;
                three_score.Text = "Result: " + ArrayRank[2].Score.ToString();
                three_date.Text = "1. " + "Date: " + ArrayRank[2].Date.ToString();
                no3.Visibility = Visibility.Visible;

                four_nick.Text = "4. " + ArrayRank[3].Nick;
                four_score.Text = "Result: " + ArrayRank[3].Score.ToString();
                four_date.Text = "Date: " + ArrayRank[3].Date.ToString();
                no4.Visibility = Visibility.Visible;

                five_nick.Text = "5. " + ArrayRank[4].Nick;
                five_score.Text = "Result: " + ArrayRank[4].Score.ToString();
                five_date.Text = "Date: " + ArrayRank[4].Date.ToString();
                no5.Visibility = Visibility.Visible;
            }
            catch (Exception e) { }


        }
    }
}