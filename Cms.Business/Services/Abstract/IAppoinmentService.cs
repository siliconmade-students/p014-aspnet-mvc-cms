﻿using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services.Abstract
{
	public interface IAppoinmentService
	{
		void Create(AppoinmentDto appoinment);
	}
}
