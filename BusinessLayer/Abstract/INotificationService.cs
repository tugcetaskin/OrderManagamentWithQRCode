﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TGetUnreadNotificationCount();
        List<Notification> TGetUnreadNotificationList();
        void TMarkAsRead(int id);
        void TMarkAsUnread(int id);
        bool TGetStatus(int id);
    }
}
