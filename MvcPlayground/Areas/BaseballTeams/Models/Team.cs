namespace MvcPlayground.Areas.BaseballTeams.Models
{
    public class Team
    {
        public Manager Manager { get; set; }
        public Player[] Players { get; set; }
    }
}
