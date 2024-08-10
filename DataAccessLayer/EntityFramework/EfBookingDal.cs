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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void CancelRezervation(int id)
        {
            using var _context = new Context();
            var value = _context.Bookings.Where(x => x.Id == id).FirstOrDefault();
            value.Description = "Rezervasyon İptal Edildi";
            _context.SaveChanges();
        }

        public void ConfirmRezervation(int id)
        {
            using var _context = new Context();
            var value = _context.Bookings.Where(x => x.Id == id).FirstOrDefault();
            value.Description = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }
    }
}
