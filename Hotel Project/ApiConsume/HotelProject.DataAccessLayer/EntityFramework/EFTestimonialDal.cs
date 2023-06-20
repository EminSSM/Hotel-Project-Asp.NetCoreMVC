using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EFTestimonialDal(Context context) : base(context)
        {
        }
    }
}
