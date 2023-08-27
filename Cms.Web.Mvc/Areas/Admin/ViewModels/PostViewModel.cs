using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Areas.Admin.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // Diğer özellikler

        public List<int> SelectedCategories { get; set; }
        public List<SelectListItem> AllCategories { get; set; }
    }
}
