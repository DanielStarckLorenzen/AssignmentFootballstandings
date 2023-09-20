namespace AssignmentFootballstandings;

public static class LeagueController
{
    public static void SetTeamPlacements(League league)
    {
        Console.WriteLine("Setting team placements...");
        //Sort the teams by points, then by goal difference, then by goals scored
        league.Teams = league.Teams.OrderByDescending(team => team.Points).ThenByDescending(team => team.GoalDifference).ThenByDescending(team => team.GoalsScored).ToList();
        
        //Set the position of each team
        for (int i = 0; i < league.Teams.Count; i++)
        {
            league.Teams[i].Position = i + 1;
        }
    }

    public static void SplitTheLeague(League league, string matchScenarioPath)
    {
        //Split the league into two groups by 6 teams
        List<Team> championshipGroup = league.Teams.GetRange(0, 6);
        List<Team> relegationGroup = league.Teams.GetRange(6, 6);
        
        //Sort the teams by points, then by goal difference, then by goals scored
        championshipGroup = championshipGroup.OrderByDescending(team => team.Points).ThenByDescending(team => team.GoalDifference).ThenByDescending(team => team.GoalsScored).ToList();
        relegationGroup = relegationGroup.OrderByDescending(team => team.Points).ThenByDescending(team => team.GoalDifference).ThenByDescending(team => team.GoalsScored).ToList();


        //Set the position of each team
        for (int i = 0; i < championshipGroup.Count; i++)
        {
            championshipGroup[i].Position = i + 1;
        }

        for (int i = 0; i < relegationGroup.Count; i++)
        {
            relegationGroup[i].Position = i + 1;
        }

        MatchController.SetMatchResults(league, true, matchScenarioPath);
    }

    public static List<Team> SplitChampionshipGroup(League league)
    {
        //Split the top 6 teams from the league into a championship group
        List<Team> championshipGroup = league.Teams.GetRange(0, 6);

        return championshipGroup;
    }
    
    public static List<Team> SplitRelegationGroup(League league)
    {
        //Split the bottom 6 teams from the league into a relegation group
        List<Team> relegationGroup = league.Teams.GetRange(6, 6);
        
        //Change the position of the teams in the relegation group
        for (int i = 0; i < relegationGroup.Count; i++)
        {
            relegationGroup[i].Position = i + 1;
        }
        
        return relegationGroup;
    }

    public static List<Team> SetTeamPositions(List<Team> group)
    {
        group = group.OrderByDescending(team => team.Points).ThenByDescending(team => team.GoalDifference).ThenByDescending(team => team.GoalsScored).ToList();
        for (int i = 0; i < group.Count; i++)
        {
            group[i].Position = i + 1;   
        }

        return group;
    }
}