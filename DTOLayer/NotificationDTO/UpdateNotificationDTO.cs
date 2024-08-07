using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.NotificationDTO
{
    public class UpdateNotificationDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
