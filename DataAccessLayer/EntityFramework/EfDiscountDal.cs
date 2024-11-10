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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(Context context) : base(context)
        {
        }

        public decimal AvarageDiscountPercentage()
        {
            using var context = new Context();
            var result = context.Discounts
                    .Select(x => Convert.ToDecimal(x.Amount))
                    .Average();
            return result;
        }

        public int BiggestDiscount()
        {
            using var context = new Context();
            var result = context.Discounts
                    .Select(x => Convert.ToInt32(x.Amount))
                    .Max();
            return result;
        }

        public void ChangeStatus(int id)
        {
            using var context = new Context();
            var value = context.Discounts.Where(x => x.Id == id).FirstOrDefault();
            if(value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            context.SaveChanges();
        }

        public List<Discount> GetLastTwo()
        {
            using var context = new Context();
            var values = context.Discounts.Where(x => x.Status == true).OrderByDescending(y => y.Id).Take(2).ToList();
            return values;
        }

        public int SmallestDiscount()
        {
            using var context = new Context();
            var result = context.Discounts
                    .Select(x => Convert.ToInt32(x.Amount))
                    .Min();
            return result;
        }
    }
}
