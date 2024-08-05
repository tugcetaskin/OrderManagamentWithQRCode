using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {
        }

        public About GetLastAbout()
        {
            using var context = new Context();
            var result = context.Abouts.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            return result;
        }
    }
}
