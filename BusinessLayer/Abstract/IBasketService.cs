using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByTableNum(int id);
		Basket TGetBasketByProductAndTable(int productId, int tableId);
		int TGetBasketIdByPAndT(int productId, int tableId);
	}
}
