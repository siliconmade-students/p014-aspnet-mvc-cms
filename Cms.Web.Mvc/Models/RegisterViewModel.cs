using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ad alanı 50 karakteri geçemez.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Soyad alanı 50 karakteri geçemez.")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        [Display(Name = "E-posta Adresi")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre doğrulama alanı zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Doğrulama")]
        [Compare("Password", ErrorMessage = "Şifre ve Şifre Doğrulama alanları eşleşmelidir.")]
        public string Password2 { get; set; }

        [Required(ErrorMessage = "Şehir zorunludur.")]
        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Geçersiz telefon numarası. Lütfen 10 haneli bir telefon numarası girin.")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }

        [Display(Name = "Roller")]
        public string Roles { get; set; }

    }
}
