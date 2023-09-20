namespace AssignmentFootballstandings;

public static class CSVReader
{
    public static League ReadLeague()
    {
        Console.WriteLine("Reading league...");
        string csvFilePath = "/Users/daniellorenzen/Desktop/c#/AssignmentFootballstandings/AssignmentFootballstandings/data/setup.csv";

        try
        {
            //Read the CSV file where the first line is the title of the different values. Reading the file where the attributes are seperated by semicolons.
            using (var reader = new StreamReader(csvFilePath))
            {
                //Skip the first line
                reader.ReadLine();
                var line = reader.ReadLine();
                var values = line.Split(';');
            
                var leagueName = values[0];
                var numberOfPositionsToChampionsLeague = int.Parse(values[1]);
                var numberOfPositionsToEuropaLeagueL = int.Parse(values[2]);
                var numberOfPositionsToConferenceLeague = int.Parse(values[3]);
                var numberOfPositionsToPromotion = int.Parse(values[4]);
                var numberOfPositionsToRelegation = int.Parse(values[5]);
            
                var league = new League(leagueName, numberOfPositionsToChampionsLeague, numberOfPositionsToEuropaLeagueL, numberOfPositionsToConferenceLeague, numberOfPositionsToPromotion, numberOfPositionsToRelegation);
            
                return league;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {csvFilePath}");
            throw;
        }
    }
    
    public static void ReadTeams(League league)
    {
        Console.WriteLine("Reading teams...");
        string csvFilePath = "/Users/daniellorenzen/Desktop/c#/AssignmentFootballstandings/AssignmentFootballstandings/data/teams.csv";
        
        //Read the CSV file where the first line is the title of the different values. Reading the file where the attributes are seperated by semicolons.
        using (var reader = new StreamReader(csvFilePath))
        {
            //Skip the first line
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                
                var abbreviation = values[0];
                var clubName = values[1];
                var specialRanking = values[2];
                
                var team = new Team(abbreviation, clubName, specialRanking);
                league.Teams.Add(team);
            }
        }
    }

    public static void ReadRounds(League league, bool isLeagueSplit)
    {
        Console.WriteLine("Reading rounds...");
        string roundsCsvFolderPath = "/Users/daniellorenzen/Desktop/c#/AssignmentFootballstandings/AssignmentFootballstandings/data/rounds";

        // Get a list of CSV file paths
        var roundFiles = Directory.GetFiles(roundsCsvFolderPath).OrderBy(f => f).ToList();

        // Determine the range of rounds to read based on the isLeagueSplit bool
        int startRound = isLeagueSplit ? 23 : 1;
        int endRound = isLeagueSplit ? roundFiles.Count : 22;

        for (int roundIndex = startRound - 1; roundIndex < endRound; roundIndex++)
        {
            var filePath = roundFiles[roundIndex];

            try
            {
                // Read the CSV file where the attributes are separated by semicolons.
                using (var reader = new StreamReader(filePath))
                {
                    // Skip the first line
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        var homeTeamAbbreviation = values[0];
                        var awayTeamAbbreviation = values[1];
                        var score = values[2];
                        var homeTeamGoals = int.Parse(score.Split('-')[0]);
                        var awayTeamGoals = int.Parse(score.Split('-')[1]);

                        //Find the home team in the league
                        var homeTeam = league.Teams.Find(team => team.Abbreviation == homeTeamAbbreviation);
                        //Find the away team in the league
                        var awayTeam = league.Teams.Find(team => team.Abbreviation == awayTeamAbbreviation);

                        //Add the goals to the teams
                        homeTeam.GoalsScored += homeTeamGoals;
                        homeTeam.GoalsConceded += awayTeamGoals;
                        awayTeam.GoalsScored += awayTeamGoals;
                        awayTeam.GoalsConceded += homeTeamGoals;

                        //Add the matches played to the teams
                        homeTeam.MatchesPlayed++;
                        awayTeam.MatchesPlayed++;

                        //Add the points to the teams
                        if (homeTeamGoals > awayTeamGoals)
                        {
                            homeTeam.Points += 3;
                            homeTeam.Wins++;
                            awayTeam.Losses++;
                        }
                        else if (homeTeamGoals == awayTeamGoals)
                        {
                            homeTeam.Points++;
                            homeTeam.Draws++;
                            awayTeam.Points++;
                            awayTeam.Draws++;
                        }
                        else
                        {
                            awayTeam.Points += 3;
                            awayTeam.Wins++;
                            homeTeam.Losses++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading file: {filePath}");
                throw;
            }
        }
    }
    
    public static void CreateRoundCSV(League league, List<Team> teams, int roundNumber, string roundType)
    {
        //Create the championship and relegation rounds in the rounds folder and write the results to the CSV files
        //Go from round 23 to round 34, but only the championship group teams can meet each other and vise versa
        //One csv file should only have 3 matches
        
        string csvFilePath = $"/Users/daniellorenzen/Desktop/c#/AssignmentFootballstandings/AssignmentFootballstandings/data/rounds/{roundType}{roundNumber}.csv";
        
        //Create the CSV file
        using (var writer = new StreamWriter(csvFilePath))
        {
            //Write the first line
            writer.WriteLine("Home Team Abbreviated;Away Team Abbreviated;Score");

           //Write the matches
           foreach (var team in teams)
           {
                
           }
        }
    }
}