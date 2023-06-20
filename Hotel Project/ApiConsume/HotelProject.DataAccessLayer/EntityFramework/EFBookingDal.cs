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
    public class EFBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EFBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusChangeApproved(Booking booking)
        {
           var context = new Context();
           var values = context.Bookings.Where(x => x.BookingId == booking.BookingId).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved2(int id)
        {
            Context context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            Context context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            Context context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            Context context = new Context();
            var values = context.Bookings.Count();
            return values;
        }

        public List<Booking> Last6Booking()
        {
            Context context = new Context();
            var booking = context.Bookings.OrderByDescending(x=>x.BookingId).Take(6).ToList();  
            return booking;
        }
    }
}
    
   

