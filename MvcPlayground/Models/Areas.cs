namespace MvcPlayground.Models
{
    public static class Areas
    {
        // TODO - instead of this, search the assembly looking for controllers that have an Screen attribute that contains the Id and Url?

        public static Area[] All =
            new[]
                {
                    new Area
                        {
                            Id = "Area1",
                            Screens =
                                new[]
                                    {
                                        new Screen
                                            {
                                                Title = "Screen 1", 
                                                Url = "/Area1/Screen1",
                                                Status = "New"
                                            },
                                        new Screen
                                            {
                                                Title = "Screen 2", 
                                                Url = "/Area1/Screen2",
                                                Status = "New"
                                            },
                                        new Screen
                                            {
                                                Title = "Screen 3", 
                                                Url = "/Area1/Screen3",
                                                Status = "New"
                                            }
                                    }
                        }
                };
    }
}