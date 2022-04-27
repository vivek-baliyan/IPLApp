namespace API.DTOs
{
    public class MatchDetailsDto
    {
        public int Id { get; set; }
        public bool IsMatchWon { get; set; }
        public bool IsTossWon { get; set; }
        public int RunsScored {get;set;}
        public int WicketsTaken { get; set; }
        public int TeamId { get; set; }
        public int MatchId { get; set; }
    }
}