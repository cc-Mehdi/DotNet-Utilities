namespace Mail_Service_Training.Models
{
    public class EmailRequest
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = true;
    }
}
