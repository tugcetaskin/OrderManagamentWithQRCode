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
    public class EfTableForCustomerDal : GenericRepository<TableForCustomer>, ITableForCustomerDal
    {
        public EfTableForCustomerDal(Context context) : base(context)
        {
        }

        public int TableCount()
        {
            using var context = new Context();
            return context.TableForCustomers.Count();
        }
    }
}
