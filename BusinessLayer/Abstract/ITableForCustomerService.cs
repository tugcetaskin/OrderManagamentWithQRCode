using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITableForCustomerService : IGenericService<TableForCustomer>
    {
        int TTableCount();
        void TMarkAsFull(int id);
        void TMarkAsAvaible(int id);
        int TGetTableIDByName(string name);
		int TNewTableId();
		TableForCustomer TAvailableOnlineTable();
	}
}
