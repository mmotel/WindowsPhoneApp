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

using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Projekt
{
    [Table]
    public class Storage : INotifyPropertyChanged, INotifyPropertyChanging
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int ScoreID { get; set; }

        private string nickValue;

        [Column]
        public string Nick
        {
            get
            {
                return nickValue;
            }
            set
            {
                NotifyPropertyChanging("Nick");
                nickValue = value;
                NotifyPropertyChanged("Nick");
            }
        }

        private int scoreValue;

        [Column]
        public int Score
        {
            get
            {
                return scoreValue;
            }
            set
            {
                NotifyPropertyChanging("Score");
                scoreValue = value;
                NotifyPropertyChanged("Score");
            }
        }

        private DateTime dateValue;

        [Column]
        public DateTime Date
        {
            get
            {
                return dateValue;
            }
            set
            {
                NotifyPropertyChanging("Date");
                dateValue = value;
                NotifyPropertyChanged("Date");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                              new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this,
                              new PropertyChangingEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }

    public class ScoreDB : DataContext
    {
        public string Name { get; set; }

        public Table<Storage> ScoresTable;

        public ScoreDB(string connection)
            : base(connection)
        {
        }

        public static void MakeDB()
        {
            using (ScoreDB newDB = new ScoreDB("Data Source=isostore:/Sample.sdf"))
            {

                if (!newDB.DatabaseExists())
                {
                    newDB.CreateDatabase();
                }

                /*Storage newScore = new Storage();
                newScore.Nick = "Test";
                newScore.Score = 900000;
                newScore.Date = DateTime.Now;

                newDB.ScoresTable.InsertOnSubmit(newScore);
                newDB.SubmitChanges();*/
            }
        }

        public List<Storage> getScores()
        {
            using (ScoreDB newDB = new ScoreDB("Data Source=isostore:/Sample.sdf"))
            {

            var allScores = from Storage storage
                                 in newDB.ScoresTable
                              select storage;

            List<Storage> scoresList = allScores.ToList<Storage>();
            App thisApp = Application.Current as App;
            scoresList.Sort(sortByScores);
            return scoresList;
                
            }
        }

        public void addScore(String nick, double score)
        {
            using (ScoreDB newDB = new ScoreDB("Data Source=isostore:/Sample.sdf"))
            {
                Storage newScore = new Storage();
                newScore.Nick = nick;
                newScore.Score = Convert.ToInt32(score);
                newScore.Date = DateTime.Now;

                newDB.ScoresTable.InsertOnSubmit(newScore);
                newDB.SubmitChanges();
            }
        }

        private static int sortByScores(Storage x, Storage y)
        {
            if (x.Score > y.Score) return -1;
            else if (x.Score == y.Score) return 0;
            else return 1;
        }

    }
}
