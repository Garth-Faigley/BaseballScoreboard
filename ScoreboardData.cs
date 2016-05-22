using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballScoreboard
{
    class ScoreboardData : INotifyPropertyChanged
    {

        private int homeScore;
        private int awayScore;
        private int currentInning;
        private int currentOut;
        private string atBat;

        public int HomeScore
        {
            get { return homeScore; }
            set { homeScore = value; OnPropertyChanged("HomeScore"); }
        }

        public int AwayScore
        {
            get { return awayScore; }
            set { awayScore = value; OnPropertyChanged("AwayScore"); }
        }

        public int CurrentInning
        {
            get { return currentInning; }
            set { currentInning = value; OnPropertyChanged("CurrentInning"); }
        }

        public int CurrentOut
        {
            get { return currentOut; }
            set { currentOut = value; OnPropertyChanged("CurrentOut"); }

        }

        public string AtBat
        {
            get { return atBat; }
            set { atBat = value; OnPropertyChanged("AtBat"); }
        }
        
        public ScoreboardData()
        {
            HomeScore = 0;
            AwayScore = 0;
            CurrentInning = 1;
            CurrentOut = 0;
            AtBat = "^";
        }


        // boilerplate code supporting PropertyChanged events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
