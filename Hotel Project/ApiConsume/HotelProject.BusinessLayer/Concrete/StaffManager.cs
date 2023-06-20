using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffdal;

        public StaffManager(IStaffDal staffdal)
        {
            _staffdal = staffdal;
        }

        public void TDelete(Staff t)
        {
            _staffdal.Delete(t);
        }

        public Staff TGetById(int id)
        {
            return _staffdal.GetById(id);
        }

        public List<Staff> TGetList()
        {
          return _staffdal.GetList();
        }

        public int TGetStaffCount()
        {
           return  _staffdal.GetStaffCount();
        }

        public void TInsert(Staff t)
        {
            _staffdal.Insert(t);
        }

        public List<Staff> TLast4Staff()
        {
            return _staffdal.Last4Staff();
        }

        public void TUpdate(Staff t)
        {
            _staffdal.Update(t);
        }
    }
}
