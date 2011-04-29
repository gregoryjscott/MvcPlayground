namespace MvcPlayground.Areas.BaseballTeams.Models
{
    public class Cardinals
    {
        public static Manager Manager { get { return new Manager {Name = "Tony La Russa"}; } }
        public static Player[] Roster =
            new[]
                {
                    new Player
                        {
                            Name = "Albert Pujols",
                            Team = Team.Cardinals
                        }
                };
    }
}