using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class MessageCategory
    {
        public int MessageCategoryID { get; set; }
        public string Title { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
