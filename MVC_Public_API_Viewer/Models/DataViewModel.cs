namespace MVC_Public_API_Viewer.Models
{
    public class DataViewModel
    {
        public class Rootobject
        {
            public int? count { get; set; }
            public Entry[]? entries { get; set; }
            public string[]? categories { get; set; }
            public string? selectedCategory { get; set; }
        }

        public class Entry
        {
            public string? API { get; set; }
            public string? Description { get; set; }
            public string? Auth { get; set; }
            public bool? HTTPS { get; set; }
            public string? Cors { get; set; }
            public string? Link { get; set; }
            public string? Category { get; set; }
        }
    }
}
