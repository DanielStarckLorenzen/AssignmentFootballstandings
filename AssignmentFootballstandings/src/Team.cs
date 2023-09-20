namespace AssignmentFootballstandings;

public class Team
{
    public string Abbreviation { get; set; }
    public string ClubName { get; set; }
    public string SpecialRanking { get; set; }
    public int Points { get; set; }
    public int GoalsScored { get; set; }
    public int GoalsConceded { get; set; }
    public int GoalDifference { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int MatchesPlayed { get; set; }
    public int Position { get; set; }
    public List<string> MatchesPlayedAgainst { get; set; }
    
    public Team (string abbreviation, string clubName, string specialRanking)
    {
        Abbreviation = abbreviation;
        ClubName = clubName;
        SpecialRanking = specialRanking;
    }
}