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
using System.IO;
using System.IO.IsolatedStorage;

namespace Projekt
{
    public class SettingsData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Boolean level60;
        private Boolean level30;
        private Boolean level15;
        private int level;
        private Boolean cat1;
        private Boolean cat2;
        private Boolean cat3;
        private Boolean cat4;
        private Boolean cat5;
        private Boolean cat6;
        private String nick;

        public SettingsData()
        {
        }

        public void saveSettings()
        {
            String settings = Level.ToString() + "\t";

            if (cat1) { settings += "1\t"; } else { settings += "0\t"; }
            if (cat2) { settings += "2\t"; } else { settings += "0\t"; }
            if (cat3) { settings += "3\t"; } else { settings += "0\t"; }
            if (cat4) { settings += "4\t"; } else { settings += "0\t"; }
            if (cat5) { settings += "5\t"; } else { settings += "0\t"; }
            if (cat6) { settings += "6\t"; } else { settings += "0\t"; }
            if (nick.Length > 0) { settings = settings + nick + "\t"; }

            saveDataIS("settings.txt", settings);
            
        }

        public void loadSettings()
        {
            String test;
            loadDataIS("settings.txt", out test);
            char[] separators = { '\t' };
            string[] words = test.Split(separators);

            //wczytywanie ustawień
            if (words.Length >= 7)
            {
                if (words[0].CompareTo("15") == 0) { Level15 = true; }
                else if (words[0].CompareTo("30") == 0) { Level30 = true; }
                else if (words[0].CompareTo("60") == 0) { Level60 = true; }

                if (Convert.ToInt32(words[1]) != 0) { cat1 = true; }
                if (Convert.ToInt32(words[2]) != 0) { cat2 = true; }
                if (Convert.ToInt32(words[3]) != 0) { cat3 = true; }
                if (Convert.ToInt32(words[4]) != 0) { cat4 = true; }
                if (Convert.ToInt32(words[5]) != 0) { cat5 = true; }
                if (Convert.ToInt32(words[6]) != 0) { cat6 = true; }

                if (words.Length >= 8) { Nick = words[7]; }
            }
            else
            {
                Level15 = false;
                Level60 = false;
                Level30 = true;
                Nick = "Player";
                cat1 = false;
                cat2 = false;
                cat3 = false;
                cat4 = false;
                cat5 = false;
                cat6 = false;
            }
        }

        public Boolean Cat1
        {
            set { cat1 = value; }
            get { return cat1; }
        }

        public Boolean Cat2
        {
            set { cat2 = value; }
            get { return cat2; }
        }

        public Boolean Cat3
        {
            set { cat3 = value; }
            get { return cat3; }
        }

        public Boolean Cat4
        {
            set { cat4 = value; }
            get { return cat4; }
        }

        public Boolean Cat5
        {
            set { cat5 = value; }
            get { return cat5; }
        }

        public Boolean Cat6
        {
            set { cat6 = value; }
            get { return cat6; }
        }

        public Boolean Level60
        {
            set { level60 = value; level = 60; }
            get { return level60; }
        }

        public Boolean Level30
        {
            set { level30 = value; level = 30; }
            get { return level30; }
        }

        public Boolean Level15
        {
            set { level15 = value; level = 15; }
            get { return level15; }
        }

        public String Nick
        {
            set
            {
                nick = value;

            }
            get { return nick; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private void saveDataIS(string filename, string text)
        {
            using (IsolatedStorageFile isf =
                          IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream rawStream =
                                 isf.CreateFile(filename))
                {
                    StreamWriter writer = new StreamWriter(rawStream);
                    writer.Write(text);
                    writer.Close();
                }
            }
        }

        public void clearIS(string filename) //funckja pomocnicza do czyszczenia pliku w Isolated Storage
        {
            using (IsolatedStorageFile isf =
                          IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream rawStream =
                                 isf.CreateFile(filename))
                {
                    StreamWriter writer = new StreamWriter(rawStream);
                    writer.Write("");
                    writer.Close();
                }
            }
        }

        private bool loadDataIS(string filename, out string result)
        {
            result = "";
            using (IsolatedStorageFile isf =
                IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(filename))
                {
                    try
                    {
                        using (IsolatedStorageFileStream rawStream =
                            isf.OpenFile(filename, System.IO.FileMode.Open))
                        {
                            StreamReader reader = new StreamReader(rawStream);
                            result = reader.ReadToEnd();
                            reader.Close();
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
