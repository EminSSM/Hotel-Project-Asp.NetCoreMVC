using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingdal;

        public BookingManager(IBookingDal bookingdal)
        {
            _bookingdal = bookingdal;
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {
            _bookingdal.BookingStatusChangeApproved(booking);
        }

        public void TBookingStatusChangeApproved2(int id)
        {
            _bookingdal.BookingStatusChangeApproved2(id);
        }

        public void TBookingStatusChangeCancel(int id)
        {
            _bookingdal.BookingStatusChangeCancel(id);
        }

        public void TBookingStatusChangeWait(int id)
        {
            _bookingdal.BookingStatusChangeWait(id);
        }

        public void TDelete(Booking t)
        {
           _bookingdal.Delete(t);
        }

        public int TGetBookingCount()
        {
          return  _bookingdal.GetBookingCount();
        }

        public Booking TGetById(int id)
        {
            return _bookingdal.GetById(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingdal.GetList();
        }

        public void TInsert(Booking t)
        {
            _bookingdal.Insert(t);
        }

        public List<Booking> TLast6Booking()
        {
           return _bookingdal.Last6Booking();
        }

        public void TUpdate(Booking t)
        {
            _bookingdal.Update(t);
        }
    }
}
