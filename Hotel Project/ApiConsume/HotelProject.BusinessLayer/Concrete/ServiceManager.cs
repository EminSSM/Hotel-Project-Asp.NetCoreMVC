using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _servicedal;

        public ServiceManager(IServiceDal servicedal)
        {
            _servicedal = servicedal;
        }

        public void TDelete(Service t)
        {
            _servicedal.Delete(t);
        }

        public Service TGetById(int id)
        {
           return _servicedal.GetById(id);
        }

        public List<Service> TGetList()
        {
            return _servicedal.GetList();
        }

        public void TInsert(Service t)
        {
            _servicedal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _servicedal.Update(t);
        }
    }
}
