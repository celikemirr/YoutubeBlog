using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.DTOS.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
		Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
		Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
		Task<Category> GetCategoryByGuid(Guid Id);
		Task<string> SafeDeleteCategoryAsync(Guid categoryId);

	}
}
