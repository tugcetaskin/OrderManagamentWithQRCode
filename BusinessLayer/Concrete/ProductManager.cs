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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public decimal TAvarageProductPrice()
        {
            return _productDal.AvarageProductPrice();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public int TGetProductCount()
        {
            return _productDal.GetProductCount();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public int TProductNumberByCategoryDessert()
        {
            return _productDal.ProductNumberByCategoryDessert();
        }

        public int TProductNumberByCategoryMain()
        {
            return _productDal.ProductNumberByCategoryMain();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public Product THighestPriceProduct()
        {
            return _productDal.HighestPriceProduct();
        }

        public Product TLowestPriceProduct()
        {
            return _productDal.LowestPriceProduct();
        }

        public decimal TAvarageMainMealPrice()
        {
            return _productDal.AvarageMainMealPrice();
        }

        public List<Product> TGetNineProducts()
        {
            return _productDal.GetNineProducts();
        }
    }
}
