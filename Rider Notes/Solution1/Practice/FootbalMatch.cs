using System;

namespace Delegates
{
    public class FootballMatch
    {
        // Subscribers will use methods that match this delegate to subscribe
        public delegate void NotifyAboutGoals(string scoringTeam, int team1score, int team2score);

        // Subscribers will add themselves to this invocation list
        public event NotifyAboutGoals NotifyOnGoalScored
        {
            add
            {
                Console.WriteLine("Subscribed");
            }
            remove
            {
                Console.WriteLine("Un Subscribed");
            }
        }

        public string Team1 { get; private set; }
        public string Team2 { get; private set; }

        public int Team1Score { get; private set; }
        public int Team2Score { get; private set; }

        public FootballMatch(string team1, string team2)
        {
            Team1 = team1;
            Team2 = team2;
        }

        public void IncreaseTeam1Score()
        {
            Team1Score++;
            // We are now just calling the delegate
            // NotifyOnGoalScored?.
        }

        public void IncreaseTeam2Score()
        {
            Team2Score++;
            // We are now just calling the delegate
            // NotifyOnGoalScored?.Invoke(Team2, Team1Score, Team2Score);

        }
    }
}