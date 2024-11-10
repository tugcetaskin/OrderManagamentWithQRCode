namespace SignalRWebUI.DTOs.MailDTOs
{
    public class CreateMailDTO
    {
        public string ReceiverEmail { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
