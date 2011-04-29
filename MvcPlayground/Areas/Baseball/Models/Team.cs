namespace MvcPlayground.Areas.Baseball.Models
{
    public class Team
    {
        public string Name { set; get; }
        public Manager Manager { get; set; }
        public Player[] Players { get; set; }
    }
}
