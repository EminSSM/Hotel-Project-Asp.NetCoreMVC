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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendmessage;

        public SendMessageManager(ISendMessageDal sendmessage)
        {
            _sendmessage = sendmessage;
        }

        public void TDelete(SendMessage t)
        {
            _sendmessage.Delete(t);
        }

        public SendMessage TGetById(int id)
        {
            return _sendmessage.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendmessage.GetList();
        }

        public int TGetSendMessageCount()
        {
            return _sendmessage.GetSendMessageCount();
        }

        public void TInsert(SendMessage t)
        {
            _sendmessage.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _sendmessage.Update(t);
        }
    }
}
