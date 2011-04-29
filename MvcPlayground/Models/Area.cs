using MvcPlayground.Areas.Security.Models;

namespace MvcPlayground.Models
{
    public class Area
    {
        public string Id { get; set; } 
        public Screen[] Screens { get; set; }
    }
}