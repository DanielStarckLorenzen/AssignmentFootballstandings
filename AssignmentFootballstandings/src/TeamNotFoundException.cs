namespace AssignmentFootballstandings;

public class TeamNotFoundException : Exception
{
    public TeamNotFoundException(string message) : base(message)
    {
        
    }
}