using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage ="Lütfen doğru bir email giriniz..")]
        [Display(Name = "Email",Prompt ="kullanici@gmail.com")]
        public string? EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Şifre",Prompt = "Şifrenizi giriniz...")]
        public string? Password { get; set; }
        [Display(Name="Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
