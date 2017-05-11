namespace _09Bridge
{
    public class EmailMessage
    {
        public EmailAddress From { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public EmailAddress To { get; set; }
    }
}