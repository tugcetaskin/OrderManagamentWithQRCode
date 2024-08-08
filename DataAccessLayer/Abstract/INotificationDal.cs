using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int GetUnreadNotificationCount();
        List<Notification> GetUnreadNotificationList();
        void MarkAsRead(int id);
        void MarkAsUnread(int id);
        bool GetStatus(int id);
    }
}
