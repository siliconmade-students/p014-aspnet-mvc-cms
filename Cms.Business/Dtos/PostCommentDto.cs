using Cms.Data.Entity.Abstract;
using Cms.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
    public class PostCommentDto : AuditDto
    {
        public int? PostDtoId { get; set; }

        public PostDto? PostDto { get; set; }

        public int? UserDtoId { get; set; }

        public UserDto? UserDto { get; set; }

        [Unicode, MaxLength(1000)]
        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
