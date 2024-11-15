﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TableForCustomerManager : ITableForCustomerService
    {
        private readonly ITableForCustomerDal _tableForCustomerDal;

        public TableForCustomerManager(ITableForCustomerDal tableForCustomerDal)
        {
            _tableForCustomerDal = tableForCustomerDal;
        }

        public void TAdd(TableForCustomer entity)
        {
            _tableForCustomerDal.Add(entity);
        }

		public TableForCustomer TAvailableOnlineTable()
		{
			return _tableForCustomerDal.AvailableOnlineTable();
		}

		public void TDelete(TableForCustomer entity)
        {
            _tableForCustomerDal.Delete(entity);
        }

        public TableForCustomer TGetById(int id)
        {
            return _tableForCustomerDal.GetById(id);
        }

        public List<TableForCustomer> TGetListAll()
        {
            return _tableForCustomerDal.GetListAll();
        }

        public int TGetTableIDByName(string name)
        {
            return _tableForCustomerDal.GetTableIDByName(name);
        }

        public void TMarkAsAvaible(int id)
        {
            _tableForCustomerDal.MarkAsAvaible(id);
        }

        public void TMarkAsFull(int id)
        {
            _tableForCustomerDal.MarkAsFull(id);
        }

		public int TNewTableId()
		{
			return _tableForCustomerDal.NewTableId();
		}

		public int TTableCount()
        {
            return _tableForCustomerDal.TableCount();
        }

        public void TUpdate(TableForCustomer entity)
        {
            _tableForCustomerDal.Update(entity);
        }
    }
}
