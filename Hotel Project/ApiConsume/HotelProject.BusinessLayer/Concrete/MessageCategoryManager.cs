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
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messagecategory;

        public MessageCategoryManager(IMessageCategoryDal messagecategory)
        {
            _messagecategory = messagecategory;
        }

        public void TDelete(MessageCategory t)
        {
            throw new NotImplementedException();
        }

        public MessageCategory TGetById(int id)
        {
            return _messagecategory.GetById(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messagecategory.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MessageCategory t)
        {
            throw new NotImplementedException();
        }
    }
}
