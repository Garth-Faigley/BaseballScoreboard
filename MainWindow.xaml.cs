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

        #region " Mouse Button Click Handlers "
        private void OutButton_Click(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "OutIncrement")
                OutChange(true);
            else
                OutChange(false);
        }

        private void InningButton_Click(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "InningIncrement")
                InningChange(true);
            else
                InningChange(false);
        }

        private void HomeScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "HomeIncrement")
                HomeScoreChange(true);
            else
                HomeScoreChange(false);
        }

        private void AwayScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button sendingButton = (Button)sender;
            if (sendingButton.Name == "AwayIncrement")
                AwayScoreChange(true);
            else
                AwayScoreChange(false);
        }
        #endregion

        #region " KeyDown and Presenter Button Click Handlers "
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.I || e.Key == Key.Next)
            {
                InningChange(true);
            }

            if (e.Key == Key.A || e.Key == Key.OemPeriod )
            {
                AwayScoreChange(true);
            }
            if (e.Key == Key.H || e.Key == Key.F5)
            {
                HomeScoreChange(true);
            }
            if (e.Key == Key.O || e.Key == Key.PageUp)
            {
                OutChange(true);
            }
        }
        #endregion

        #region " Increment / Decrement numbers "
        private void OutChange(bool isIncrease)
        {
            if (isIncrease)
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

        private void InningChange(bool isIncrease)
        {
            if (isIncrease)
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
            }
        }

        private void HomeScoreChange(bool isIncrease)
        {
            if (isIncrease)
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

        private void AwayScoreChange(bool isIncrease)
        {
            if (isIncrease)
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
#endregion

    }
}
