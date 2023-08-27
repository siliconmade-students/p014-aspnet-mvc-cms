using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Models
{
    public class BlogDetailViewModel
    {
        [ValidateNever]
        public DateTime CreatedAt { get; set; }
        [ValidateNever]
        public DateTime? UpdatedAt { get; set; }

        [ValidateNever]
        public UserDto User { get; set; }
        [ValidateNever]
        public string Title { get; set; }
        [ValidateNever]
        public string Content { get; set; }

        [ValidateNever]
        public List<DepartmentDto>? Departments { get; set; }
        [ValidateNever]
        public List<PostCommentDto> Comments { get; set; }

        [ValidateNever]
        public PostImageDto? PostImageDto { get; set; }


        //[MinLength(3, ErrorMessage = "İsim en az 3 harf olabilir"),MaxLength(40, ErrorMessage = "İsim en fazla 40 harf olabilir"),Display( Prompt ="İsim")]
        //public string CommentName { get; set; }
        [MinLength(3, ErrorMessage = "Yorum en az 3 harf olabilir"),MaxLength(150, ErrorMessage = "Yorum en fazla 150 harf olabilir"), Display(Prompt = "Yorum")]
        public string Comment { get; set; }
        //[EmailAddress(ErrorMessage ="Lütfen geçerli bir E-mail giriniz"), Display(Prompt = "Email")]
        //public string CommentEmail { get; set; }
    }
}
