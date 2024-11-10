using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        List<Product> GetNineProducts();
        int GetProductCount();
        int ProductNumberByCategoryMain();
        int ProductNumberByCategoryDessert();
        decimal AvarageProductPrice();
        Product HighestPriceProduct();
        Product LowestPriceProduct();
        decimal AvarageMainMealPrice();
    }
}
