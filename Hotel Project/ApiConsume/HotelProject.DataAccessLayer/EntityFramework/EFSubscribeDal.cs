using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
        public EFSubscribeDal(Context context) : base(context)
        {
        }
    }
}
