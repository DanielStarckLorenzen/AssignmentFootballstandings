namespace AssignmentFootballstandings;

public class League
{
    public string LeagueName { get; set; }
    public int numberOfPositionsToChampionsLeague { get; set; }
    public int numberOfPositionsToEuropaLeagueL { get; set; }
    public int numberOfPositionsToConferenceLeague { get; set; }
    public int numberOfPositionsToPromotion { get; set; }
    public int numberOfPositionsToRelegation { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    
    public League (string leagueName, int numberOfPositionsToChampionsLeague, int numberOfPositionsToEuropaLeagueL, int numberOfPositionsToConferenceLeague, int numberOfPositionsToPromotion, int numberOfPositionsToRelegation)
    {
        LeagueName = leagueName;
        this.numberOfPositionsToChampionsLeague = numberOfPositionsToChampionsLeague;
        this.numberOfPositionsToEuropaLeagueL = numberOfPositionsToEuropaLeagueL;
        this.numberOfPositionsToConferenceLeague = numberOfPositionsToConferenceLeague;
        this.numberOfPositionsToPromotion = numberOfPositionsToPromotion;
        this.numberOfPositionsToRelegation = numberOfPositionsToRelegation;
    }
}