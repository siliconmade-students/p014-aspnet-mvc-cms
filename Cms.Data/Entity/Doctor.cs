using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Entity
{
	public class Doctor : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
