using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Repositories.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Task AddCategoryAsync(Category category);
        Task RemoveCategory(int categoryId);
        Task<Category> UpdateCategory(Category category);
        Task<Category> FindByIdCategory(int categoryId);
    }
}
