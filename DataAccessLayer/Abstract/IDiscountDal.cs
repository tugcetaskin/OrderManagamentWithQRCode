﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        void ChangeStatus(int id);
        List<Discount> GetLastTwo();

        decimal AvarageDiscountPercentage();

        int BiggestDiscount();
        int SmallestDiscount();
    }
}
