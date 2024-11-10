using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.ContactDTO
{
    public class ResultContactDTO
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FooterDescription { get; set; }
        public string OpenInfoTitle { get; set; }
        public string OpenDaysInfo { get; set; }
        public string OpenHoursInfo { get; set; }
    }
}
