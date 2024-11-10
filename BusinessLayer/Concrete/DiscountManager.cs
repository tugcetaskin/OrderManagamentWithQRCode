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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public decimal TAvarageDiscountPercentage()
        {
            return _discountDal.AvarageDiscountPercentage();
        }

        public int TBiggestDiscount()
        {
            return _discountDal.BiggestDiscount();
        }

        public void TChangeStatus(int id)
        {
            _discountDal.ChangeStatus(id);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount TGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> TGetLastTwo()
        {
            return _discountDal.GetLastTwo();
        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public int TSmallestDiscount()
        {
            return _discountDal.SmallestDiscount();
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
