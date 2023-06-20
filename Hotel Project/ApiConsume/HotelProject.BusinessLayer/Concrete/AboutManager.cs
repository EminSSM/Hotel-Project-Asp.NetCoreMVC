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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void TDelete(About t)
        {
            _aboutdal.Delete(t);
        }

        public About TGetById(int id)
        {
          return  _aboutdal.GetById(id);
        }

        public List<About> TGetList()
        {
            return _aboutdal.GetList();
        }

        public void TInsert(About t)
        {
            _aboutdal.Insert(t);
        }

        public void TUpdate(About t)
        {
           _aboutdal.Update(t);
        }
    }
}
