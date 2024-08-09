using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITableForCustomerDal : IGenericDal<TableForCustomer>
    {
        int TableCount();
        void MarkAsFull(int id);
        void MarkAsAvaible(int id);
    }
}
