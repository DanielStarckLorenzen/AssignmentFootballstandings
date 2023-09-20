namespace AssignmentFootballstandings;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        program.Run();
    }
    
    public void Run()
    {
        Console.WriteLine("Running...");
        League league = CSVReader.ReadLeague();
        CSVReader.ReadTeams(league);
        
        MatchController.SetMatchResults(league, false);
        
        LeagueController.SetTeamPlacements(league);
        
        //Sort teams by position
        league.Teams = league.Teams.OrderBy(team => team.Position).ToList();
        
        Console.WriteLine($"POS | {"Abbreviation",-3} ({"ClubName)",-16} |  MP  |  W  |  D  |  L  |  GF  |  GA  |  GD  |  Pts");
        foreach (var team in league.Teams)
        {
            //Color the first line green
            switch (team.Position)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 2:
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 4:
                case 5:
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 11:
                case 12:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine($"{team.Position + ".",-3} | " +
                              $"{team.Abbreviation,-3} ({team.ClubName + ")",-25} | " +
                              $" {team.MatchesPlayed,-3} | " +
                              $" {team.Wins,-2} | " +
                              $" {team.Draws,-2} | " +
                              $" {team.Losses,-2} | " +
                              $" {team.GoalsScored,-2}  | " +
                              $" {team.GoalsConceded,-2}  | " +
                              $" {team.GoalDifference,-2}  | " +
                              $" {team.Points,-2}");
        }
        Console.ForegroundColor = ConsoleColor.White;
        
        List<Team> championshipGroup = LeagueController.SplitChampionshipGroup(league);
        List<Team> relegationGroup = LeagueController.SplitRelegationGroup(league);


        //Generate the championship and relegation rounds
        //TO DO: MatchController.CreateChampionshipAndRelegationRounds(league, championshipGroup, relegationGroup);
        LeagueController.SplitTheLeague(league);
        
        Console.WriteLine("\nChampionship group:");
        Console.WriteLine($"POS | {"Abbreviation",-3} ({"ClubName)",-16} |  MP  |  W  |  D  |  L  |  GF  |  GA  |  GD  |  Pts");
        foreach (var team in championshipGroup)
        {
            //Color the first line green
            switch (team.Position)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 2:
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine($"{team.Position + ".",-3} | " +
                              $"{team.Abbreviation,-3} ({team.ClubName + ")",-25} | " +
                              $" {team.MatchesPlayed,-3} | " +
                              $" {team.Wins,-2} | " +
                              $" {team.Draws,-2} | " +
                              $" {team.Losses,-2} | " +
                              $" {team.GoalsScored,-2}  | " +
                              $" {team.GoalsConceded,-2}  | " +
                              $" {team.GoalDifference,-2}  | " +
                              $" {team.Points,-2}");
        }
        
        Console.WriteLine("\nRelegation group:");
        Console.WriteLine($"POS | {"Abbreviation",-3} ({"ClubName)",-16} |  MP  |  W  |  D  |  L  |  GF  |  GA  |  GD  |  Pts");
        foreach (var team in relegationGroup)
        {
            //Color the first line green
            switch (team.Position)
            {
                case 5:
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine($"{team.Position + ".",-3} | " +
                              $"{team.Abbreviation,-3} ({team.ClubName + ")",-25} | " +
                              $" {team.MatchesPlayed,-3} | " +
                              $" {team.Wins,-2} | " +
                              $" {team.Draws,-2} | " +
                              $" {team.Losses,-2} | " +
                              $" {team.GoalsScored,-2}  | " +
                              $" {team.GoalsConceded,-2}  | " +
                              $" {team.GoalDifference,-2}  | " +
                              $" {team.Points,-2}");
        }
    }
}