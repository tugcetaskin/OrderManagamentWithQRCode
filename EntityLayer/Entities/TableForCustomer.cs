﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class TableForCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int TableFor {  get; set; }
        public List<Basket> Basket { get; set; }
    }
}
