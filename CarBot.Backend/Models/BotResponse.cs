namespace CarBot.Backend.Models
{
    public class BotResponse
    {
        public string Type { get; set; }

        public string Text { get; set; }

        public bool Markdown { get; set; }

        public bool Value { get; set; }
    }
}