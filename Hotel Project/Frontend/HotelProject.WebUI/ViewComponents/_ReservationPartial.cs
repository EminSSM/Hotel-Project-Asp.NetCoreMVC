using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents
{
    public class _ReservationPartial : ViewComponent
    {
        public IViewComponentResult Invoke ()
        { 
            return View();
        }
    }
}
