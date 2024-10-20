namespace TriviaTapWeb.Models
{
    public class JokeResponse
    {
        public string Setup { get; set; }
        public string Delivery { get; set; }
        public string Joke { get; set; }
        public bool? Flagged { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
    }
}
