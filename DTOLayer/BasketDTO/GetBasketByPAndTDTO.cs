using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.BasketDTO
{
    public class GetBasketByPAndTDTO
    {
        public int ProductId { get; set; }
        public int TableId { get; set; }
    }
}
