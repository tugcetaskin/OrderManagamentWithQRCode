﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.OrderDetailDTO
{
    public class CreateOrderDetailDTO
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
