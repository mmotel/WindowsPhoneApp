using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Projekt
{
    public class StagesData : INotifyPropertyChanged
    {
        App thisApp = Application.Current as App;
        public event PropertyChangedEventHandler PropertyChanged;

        private double cash;
        private double[] bets = new double[5];
        private double rem_cash;

        public StagesData()
        {
            Cash = thisApp.game.Cash;
        }

        public double Cash {
            set
            {
                cash = value;
            }
            get
            {
                return cash;
            }
        }

        public double Rem_cash
        {
            get
            {
                rem_cash = cash - Bet1 - Bet2 - Bet3 - Bet4;
                return rem_cash;
            }
            set
            {
                rem_cash = value;
            }
        }

        public double getBets(int n)
        {
            return bets[n];
        }

        public void setBets(int n, double value)
        {
            bets[n] = value;
        }

        public double Bet1
        {
            get
            {
                return bets[1];
            }
            set
            {
                if (value - bets[1] < rem_cash)
                {
                    bets[1] = value - value % 50000;
                }
                else
                {
                    bets[1] = bets[1] + rem_cash;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Rem_cash"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bet1"));
            }
        }

        public double Bet2
        {
            get
            {
                return bets[2];
            }
            set
            {
                if (value - bets[2] < rem_cash)
                {
                    bets[2] = value - value % 50000;
                }
                else
                {
                    bets[2] = bets[2] + rem_cash;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Rem_cash"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bet2"));
            }
        }

        public double Bet3
        {
            get
            {
                return bets[3];
            }
            set
            {
                if (value - bets[3] < rem_cash)
                {
                    bets[3] = value - value % 50000;
                }
                else
                {
                    bets[3] = bets[3] + rem_cash;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Rem_cash"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bet3"));
            }
        }

        public double Bet4
        {
            get
            {
                return bets[4];
            }
            set
            {
                if (value - bets[4] < rem_cash)
                {
                    bets[4] = value - value % 50000;
                }
                else
                {
                    bets[4] = bets[4] + rem_cash;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Rem_cash"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bet4"));
            }
        }

    }
}
