using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public decimal AvarageMainMealPrice()
        {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.Name == "Ana Yemek").Select(z => z.Id).FirstOrDefault())).Average(w => w.Price);
        }

        public decimal AvarageProductPrice()
        {
            using var context = new Context();
            return context.Products.Average(x => x.Price);
        }

        public int GetProductCount()
        {
            using var context = new Context();
            return context.Products.Count();
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new Context();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public Product HighestPriceProduct()
        {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).FirstOrDefault();
        }

        public Product LowestPriceProduct()
        {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).FirstOrDefault();
        }

        public int ProductNumberByCategoryDessert()
        {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(c => c.Name == "Tatlı").Select(z => z.Id).FirstOrDefault())).Count();
        }

        public int ProductNumberByCategoryMain()
        {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(c => c.Name == "Ana Yemek").Select(z => z.Id).FirstOrDefault())).Count();
        }
    }
}
