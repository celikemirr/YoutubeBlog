using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Entity.DTOS.Categories
{
	public class CategoryUpdateDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
