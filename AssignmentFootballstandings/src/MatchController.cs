namespace AssignmentFootballstandings;

public class MatchController
{
    public static void SetMatchResults(League league, bool isLeagueSplit, string matchScenarioPath)
    {
        Console.WriteLine("Setting match results...");
        CSVReader.ReadRounds(league, isLeagueSplit, matchScenarioPath);
        
        //Set the goal difference for each team
        foreach (var team in league.Teams)
        {
            int goalDifference = team.GoalsScored - team.GoalsConceded;
            team.GoalDifference = goalDifference;
        }
    }

    public static void CreateChampionshipAndRelegationRounds(League league, List<Team> championshipGroup, List<Team> relegationGroup)
    {
        //Create the championship and relegation rounds in the rounds folder and write the results to the CSV files
        //Go from round 23 to round 34, but only the championship group teams can meet each other and vise versa
        //The layout should be like this per csv file
        //Home Team Abbreviated;Away Team Abbreviated;Score
        // FCK;BIF;6-1
        // RFC;OB;1-1
        // VFF;FCM;0-2
        // FCN;AGF;1-1
        // LBK;ACH;0-2
        // SIF;AAB;0-0
        for (int i = 23; i < 35; i++)
        {
            //Create the championship round
            CSVReader.CreateRoundCSV(league, championshipGroup, i, "championship");
            
            //Create the relegation round
            CSVReader.CreateRoundCSV(league, relegationGroup, i, "relegation");
        }
    }
}