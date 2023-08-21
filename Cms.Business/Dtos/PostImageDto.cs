using Cms.Data.Entity.Abstract;
using Cms.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{

    public class PostImageDto : AuditDto
    {
        public int PostDtoId { get; set; }
        public PostDto PostDto { get; set; }

        [MaxLength(400)]
        public string ImagePath { get; set; }
    }
}
