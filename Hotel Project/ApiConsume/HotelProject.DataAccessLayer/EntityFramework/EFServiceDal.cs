using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFServiceDal : GenericRepository<Service>, IServiceDal
    {
        public EFServiceDal(Context context) : base(context)
        {
        }
    }
}
