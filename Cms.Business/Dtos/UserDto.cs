using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
