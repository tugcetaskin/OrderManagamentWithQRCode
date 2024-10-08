﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public bool TGetStatus(int id)
        {
            return _notificationDal.GetStatus(id);
        }

        public int TGetUnreadNotificationCount()
        {
            return _notificationDal.GetUnreadNotificationCount();
        }

        public List<Notification> TGetUnreadNotificationList()
        {
            return _notificationDal.GetUnreadNotificationList();
        }

        public void TMarkAsRead(int id)
        {
            _notificationDal.MarkAsRead(id);
        }

        public void TMarkAsUnread(int id)
        {
            _notificationDal.MarkAsUnread(id);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
