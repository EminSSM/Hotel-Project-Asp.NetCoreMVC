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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appuserdal;

        public AppUserManager(IAppUserDal appuserdal)
        {
            _appuserdal = appuserdal;
        }

        public int TAppUserCount()
        {
            return _appuserdal.AppUserCount();  
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            return _appuserdal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appuserdal.GetList();
        }

        public void TInsert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TUserListWithWorkLocation()
        {
            return _appuserdal.UserListWithWorkLocation();
        }

        public List<AppUser> TUsersListWithWorkLocation()
        {
            return _appuserdal.UsersListWithWorkLocation();
        }
    }
}
