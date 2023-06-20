using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules
{
    public class UpdateValidationRules : AbstractValidator<UpdateGuestDto>
    {
        public UpdateValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir alanı en az 3 karakter olmalıdır.");
        }
    }
}
