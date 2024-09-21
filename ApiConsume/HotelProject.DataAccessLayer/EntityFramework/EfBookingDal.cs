using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    // 'EfBookingDal' sınıfı, 'GenericRepository' sınıfından türeyen ve 'IBookingDal' arayüzünü uygulayan bir sınıftır.
    // 'Booking' tipiyle çalışacak olan bir veri erişim sınıfıdır (Data Access Layer - DAL).

    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        // Constructor, 'EfBookingDal' sınıfının bir örneği oluşturulduğunda çalışır.
        // Base sınıf olan 'GenericRepository' sınıfına, 'Context' nesnesini iletir.
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(int id)
        {
            using (var context = new Context())
            {
                var value = context.Bookings.Find(id);
                value.Status = "Onaylandı";
                context.SaveChanges();
            }
        }
    }
}
