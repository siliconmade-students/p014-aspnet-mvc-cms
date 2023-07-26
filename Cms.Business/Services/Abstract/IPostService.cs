using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services.Abstract
{
	public interface IPostService
	{
		List<PostDto> GetAll(int page = 1);

		List<PostDto> GetByCategory(string categoryName, int page = 1);


    }
}
