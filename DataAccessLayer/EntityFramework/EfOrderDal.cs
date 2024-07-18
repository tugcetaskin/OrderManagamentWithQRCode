using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new Context();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new Context();
            return context.Orders.OrderByDescending(x => x.Id).Take(1).Select(x => x.TotalPrice).FirstOrDefault();
        }

        public decimal TodaysEarningsAmount()
        {
            using var context = new Context();
            return context.Orders
                  .Where(x => x.Date == DateTime.Today)
                  .Sum(y => (decimal?)y.TotalPrice) ?? 0;
        }

        public int TotalOrderCount()
        {
            using var context = new Context();
            return context.Orders.Count();
        }
    }
}
