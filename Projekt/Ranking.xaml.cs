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
                one_nick.Text += ArrayRank[0].Nick;
                one_score.Text += ArrayRank[0].Score.ToString();
                one_date.Text += ArrayRank[0].Date.ToString();

                two_nick.Text += ArrayRank[1].Nick;
                two_score.Text += ArrayRank[1].Score.ToString();
                two_date.Text += ArrayRank[1].Date.ToString();

                three_nick.Text += ArrayRank[2].Nick;
                three_score.Text += ArrayRank[2].Score.ToString();
                three_date.Text += ArrayRank[2].Date.ToString();

                four_nick.Text += ArrayRank[3].Nick;
                four_score.Text += ArrayRank[3].Score.ToString();
                four_date.Text += ArrayRank[3].Date.ToString();

                five_nick.Text += ArrayRank[4].Nick;
                five_score.Text += ArrayRank[4].Score.ToString();
                five_date.Text += ArrayRank[4].Date.ToString();
            }
            catch (Exception e) { }


        }
    }
}