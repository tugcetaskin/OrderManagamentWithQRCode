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

		public TableForCustomer AvailableOnlineTable()
		{
			using var context = new Context();
			var tables = context.TableForCustomers.Where(x => x.Name == "Online" && x.Status == false).FirstOrDefault();
            return tables;
		}

		public int GetTableIDByName(string name)
        {
            using var context = new Context();
            var id = context.TableForCustomers.Where(x => x.Name == name).Select(y => y.Id).FirstOrDefault();
            return id;
        }

        public void MarkAsAvaible(int id)
        {
            using var context = new Context();
            var table = context.TableForCustomers.Where(x => x.Id == id).FirstOrDefault();
            table.Status = true;
            context.SaveChanges();
        }

        public void MarkAsFull(int id)
        {
            using var context = new Context();
            var table = context.TableForCustomers.Where(x => x.Id == id).FirstOrDefault();
            table.Status = false;
            context.SaveChanges();
        }

		public int NewTableId()
		{
			using var context = new Context();
            
            var values = context.TableForCustomers.OrderByDescending(y => y.Id).Select(x => x.Id).Take(1).FirstOrDefault();
            var basket = context.Baskets.Select(y => y.TableId).ToList();


			int newTableId = values+1;
			while (basket.Contains(newTableId))
			{
				newTableId++;
			}

			return newTableId;
		}

		public int TableCount()
        {
            using var context = new Context();
            return context.TableForCustomers.Count();
        }
    }
}
