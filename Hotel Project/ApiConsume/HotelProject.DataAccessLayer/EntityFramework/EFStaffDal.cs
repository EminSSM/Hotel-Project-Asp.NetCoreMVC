using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EFStaffDal(Context context) : base(context)
        {
        }

        public int GetStaffCount()
        {
            Context context = new Context();
            var values = context.Staffs.Count();
            return values;  
        }

        public List<Staff> Last4Staff()
        {
            Context context = new Context();
            var values = context.Staffs.OrderByDescending(x=>x.StaffID).Take(4).ToList();
            return values;
        }
    }
}
