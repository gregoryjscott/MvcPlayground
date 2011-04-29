namespace MvcPlayground.Areas.Baseball.Models
{
    public static class Mlb
    {
        // TODO - would be cool to scrape this data from mlb.com

        public static Team[] Teams =
            new[]
                {
                    new Team
                        {
                            Name = "Cardinals",
                            Manager = new Manager {Name = "Tony La Russa"},
                            Players = new[]
                                          {
                                              new Player
                                                  {
                                                      Name = "Albert Pujols"
                                                  }
                                          }
                        }
                };
    }
}