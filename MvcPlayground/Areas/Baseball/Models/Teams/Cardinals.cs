namespace MvcPlayground.Areas.Baseball.Models.Teams
{
    public static class Cardinals
    {
        // TODO - would be cool to scrape this data from mlb.com/...

        public static Team Team =
            new Team
                {
                    Manager = new Manager {Name = "Tony La Russa"},
                    Players = new[]
                                  {
                                      new Player
                                          {
                                              Name = "Albert Pujols",
                                              TeamName = TeamName.Cardinals
                                          }
                                  }
                };
    }
}