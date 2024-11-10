using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByTableNum(int id);
        Basket GetBasketByProductAndTable(int productId, int tableId);
        int GetBasketIdByPAndT(int productId, int tableId);
        int GetBasketIdByTable(int tableId);
	}
}
