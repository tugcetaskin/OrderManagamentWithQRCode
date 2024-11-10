using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangeStatus(int id);
        List<Discount> TGetLastTwo();
        decimal TAvarageDiscountPercentage();
        int TBiggestDiscount();
        int TSmallestDiscount();
    }
}
