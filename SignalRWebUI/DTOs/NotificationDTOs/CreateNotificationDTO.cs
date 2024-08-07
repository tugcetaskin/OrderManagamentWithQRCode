namespace SignalRWebUI.DTOs.NotificationDTOs
{
    public class CreateNotificationDTO
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
