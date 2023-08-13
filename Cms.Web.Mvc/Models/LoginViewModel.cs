using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
