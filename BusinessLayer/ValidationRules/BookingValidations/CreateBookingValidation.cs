using DTOLayer.BookingDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules.BookingValidations
{
	public class CreateBookingValidation : AbstractValidator<CreateBookingDTO>
	{
		public CreateBookingValidation()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
			RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Zorunludur.");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Alanı Zorunludur.");
			RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Sayısı Alanı Zorunludur.");
			RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Zorunludur.");

			RuleFor(x => x.Name)
				.MinimumLength(5).WithMessage("Lütfen İsim Alanına En Az 5 Karakter Veri Girişi Yapınız.")
				.MaximumLength(50).WithMessage("İsim Alanına 50 Karakterden Fazla Veri Girişi Yapamazsınız.");
			RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama Alanına 500 Karakterden Fazla Veri Girişi Yapamazsınız.");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz.");
			
		}
	}
}
