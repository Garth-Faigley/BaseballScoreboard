using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BaseballScoreboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScoreboardData scoreboardData;

        public MainWindow()
        {
            InitializeComponent();
            scoreboardData = new ScoreboardData();
            this.DataContext = scoreboardData;
        }

        private void IncrementOut(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "OutIncrement")
            {
                if (scoreboardData.CurrentOut < 3)
                {
                    scoreboardData.CurrentOut += 1;
                }
                else
                {
                    scoreboardData.CurrentOut = 0;
                }
            }
            else
            {
                if (scoreboardData.CurrentOut > 0)
                {
                    scoreboardData.CurrentOut -= 1;
                }
            }
        }


        private void IncrementInning(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "InningIncrement")
            {
                if (scoreboardData.AtBat == "^")
                {
                    scoreboardData.AtBat = "v";
                }
                else
                {
                    scoreboardData.AtBat = "^";
                    scoreboardData.CurrentInning += 1;
                }
            }
            else
            {
                //if (scoreboardData.CurrentInning > 1 && scoreboardData.AtBat != "^")
                //{
                if (scoreboardData.AtBat == "^")
                {
                    if (scoreboardData.CurrentInning > 1)
                    {
                        scoreboardData.AtBat = "v";
                        scoreboardData.CurrentInning -= 1;
                    }
                }
                else
                {
                    scoreboardData.AtBat = "^";
                }
                //}
            }
        }

        private void IncrementHome(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "HomeIncrement")
            {
                scoreboardData.HomeScore += 1;
            }
            else
            {
                if (scoreboardData.HomeScore > 0)
                {
                    scoreboardData.HomeScore -= 1;
                }
            }
        }

        private void IncrementAway(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "AwayIncrement")
            {
                scoreboardData.AwayScore += 1;
            }
            else
            {
                if (scoreboardData.AwayScore > 0)
                {
                    scoreboardData.AwayScore -= 1;
                }
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.I)
            {
                if (scoreboardData.AtBat == "^")
                {
                    scoreboardData.AtBat = "v";
                }
                else
                {
                    scoreboardData.AtBat = "^";
                    scoreboardData.CurrentInning += 1;
                }
            }
            if (e.Key == Key.A)
            {
                scoreboardData.AwayScore += 1;
            }
            if (e.Key == Key.H)
            {
                scoreboardData.HomeScore += 1;
            }
            if (e.Key == Key.O)
            {
                if (scoreboardData.CurrentOut < 3)
                {
                    scoreboardData.CurrentOut += 1;
                }
                else
                {
                    scoreboardData.CurrentOut = 0;
                }
            }
        }
    }
}
