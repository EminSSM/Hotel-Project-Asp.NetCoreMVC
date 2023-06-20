using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal,EFStaffDal>();
builder.Services.AddScoped<IStaffService,StaffManager>();

builder.Services.AddScoped<IRoomDal, EFRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<IServiceDal, EFServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<ISubscribeDal, EFSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDal, EFTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBookingDal, EFBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();


builder.Services.AddScoped<IGuestDal, EFGuestDal>();
builder.Services.AddScoped<IGuestService, GuestManager>();

builder.Services.AddScoped<ISendMessageDal, EFSendMessage>();
builder.Services.AddScoped<ISendMessageService, SendMessageManager>();

builder.Services.AddScoped<IMessageCategoryDal, EFMessageCategory>();
builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();

builder.Services.AddScoped<IWorkLocationDal, EFWorkLocationDal>();
builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();

builder.Services.AddScoped<IAppUserDal, EFAppUserDal>();
builder.Services.AddScoped<IAppUserService, AppUserManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCorse", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("OtelApiCorse");
app.UseAuthorization();

app.MapControllers();

app.Run();
