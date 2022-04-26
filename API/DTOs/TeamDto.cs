namespace API.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string? TeamName { get; set; }
        public string? ShortName { get; set; }
        public string? Owner { get; set; }
        public string? Venue { get; set; }
        public string? Coach { get; set; }
        public string? Captain { get; set; }
        public int Year { get; set; }
        public TeamLogoDto? Logo { get; set; }
    }
}