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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {
        }

		public Basket GetBasketByProductAndTable(int productId, int tableId)
		{
			using var _context = new Context();
            var basket = _context.Baskets.Where(x => x.ProductId == productId && x.TableId == tableId).Include(x => x.Product).Include(y => y.Table).FirstOrDefault();
			return basket;
		}

		public List<Basket> GetBasketByTableNum(int id)
        {
            using var _context = new Context();
            var values = _context.Baskets.Where(x => x.TableId == id).Include(y => y.Product).ToList();
            return values;
        }

		public int GetBasketIdByPAndT(int productId, int tableId)
		{
			using var _context = new Context();
			var basket = _context.Baskets.Where(x => x.ProductId == productId && x.TableId == tableId).FirstOrDefault();
			if(basket == null)
			{
				return 0;
			}
			return basket.Id;
		}

		public int GetBasketIdByTable(int tableId)
		{
			using var _context = new Context();
			var basket = _context.Baskets.Where(x => x.TableId == tableId).FirstOrDefault();
			return basket.Id;
		}
	}
}
