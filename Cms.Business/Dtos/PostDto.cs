using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
    public class PostDto : AuiditDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<CategoryDto>? Categories { get; set; }
    }
}
