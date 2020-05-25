using ApiWithToken.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Service
{
    public interface ICategoryService
    {
        CategoryListResponse GetCategories();
        Task<CategoryResponse> AddCategoryAsync(Category category);
        Task<CategoryResponse> RemoveCategory(int categoryId);
        Task<CategoryResponse> UpdateCategory(Category category);
        Task<CategoryResponse> FindByIdCategory(int categoryId);
    }
}
