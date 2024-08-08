using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(Context context) : base(context)
        {
        }

        public bool GetStatus(int id)
        {
            using var _context = new Context();
            return _context.Notifications.Where(x => x.Id == id).Select(x => x.Status).FirstOrDefault();
        }

        public int GetUnreadNotificationCount()
        {
            using var _context = new Context();
            return _context.Notifications.Count(x => !x.Status);
        }

        public List<Notification> GetUnreadNotificationList()
        {
            using var _context = new Context();
            return _context.Notifications.Where(x => !x.Status).ToList();
        }

        public void MarkAsRead(int id)
        {
            using var _context = new Context();
            var notif = _context.Notifications.Where(x => x.Id == id).FirstOrDefault();
            if(notif != null)
            {
                notif.Status = true;
                _context.SaveChanges();
            }
        }

        public void MarkAsUnread(int id)
        {
            using var _context = new Context();
            var notif = _context.Notifications.Where(x => x.Id == id).FirstOrDefault();
            if (notif != null)
            {
                notif.Status = false;
                _context.SaveChanges();
            }
        }
    }
}
