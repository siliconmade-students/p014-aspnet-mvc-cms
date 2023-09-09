using Cms.Business.Dtos.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Cms.Business.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public string? PhotoPath { get; set; }
    }
}
