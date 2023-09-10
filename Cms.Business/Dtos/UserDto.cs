using Cms.Business.Dtos.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Cms.Business.Dtos
{
    public class UserDto : BaseDto
    {
		[Required(ErrorMessage = "E-posta adresi zorunludur.")]
		[EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre zorunludur.")]
		[MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Ad alanı zorunludur.")]
		[MaxLength(20, ErrorMessage = "Ad alanı 20 karakteri geçemez.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Soyad alanı zorunludur.")]
		[MaxLength(20, ErrorMessage = "Soyad alanı 20 karakteri geçemez.")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Şehir zorunludur.")]
		public string City { get; set; }

		[Required(ErrorMessage = "Telefon numarası zorunludur.")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Geçersiz telefon numarası. Lütfen 10 haneli bir telefon numarası girin.")]
		public string Phone { get; set; }

	}
}
