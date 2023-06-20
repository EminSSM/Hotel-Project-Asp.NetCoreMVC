﻿using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        { 
            var values = _staffService.TGetStaffCount();
            return Ok(values);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var values = _bookingService.TGetBookingCount();
            return Ok(values);
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var values = _appUserService.TAppUserCount();
            return Ok(values);
        }
        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            var values = _roomService.TGetRoomCount();
            return Ok(values);
        }
    }
}
