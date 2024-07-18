using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TGetProductCount();
        int TProductNumberByCategoryMain();
        int TProductNumberByCategoryDessert();
        decimal TAvarageProductPrice();
        Product THighestPriceProduct();
        Product TLowestPriceProduct();
        decimal TAvarageMainMealPrice();
    }
}
