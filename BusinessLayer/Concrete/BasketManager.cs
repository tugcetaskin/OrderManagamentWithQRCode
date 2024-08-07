using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

		public Basket TGetBasketByProductAndTable(int productId, int tableId)
		{
			return _basketDal.GetBasketByProductAndTable(productId, tableId);
		}

		public List<Basket> TGetBasketByTableNum(int id)
        {
            return _basketDal.GetBasketByTableNum(id);
        }

		public int TGetBasketIdByPAndT(int productId, int tableId)
		{
			return _basketDal.GetBasketIdByPAndT(productId, tableId);
		}

		public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public List<Basket> TGetListAll()
        {
            return _basketDal.GetListAll();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
