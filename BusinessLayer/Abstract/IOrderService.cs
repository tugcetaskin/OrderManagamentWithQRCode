﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TActiveOrderCount();
        int TTotalOrderCount();
        decimal TTodaysEarningsAmount();
        decimal TLastOrderPrice();

    }
}
