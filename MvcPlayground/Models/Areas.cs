using MvcPlayground.Areas.Security.Models;

namespace MvcPlayground.Models
{
    public static class Areas
    {
        // TODO - instead of this, search the assembly looking for controllers that have an Screen attribute

        public static Area[] All =
            new[]
                {
                    new Area
                        {
                            Id = "BaseballTeam",
                            Screens = new[]
                                          {
                                              new Screen {Id = "Catchers"},
                                              new Screen {Id = "Pitchers"},
                                              new Screen {Id = "Infielders"},
                                              new Screen {Id = "Outfielders"}
                                          }
                        }
                };
    }
}