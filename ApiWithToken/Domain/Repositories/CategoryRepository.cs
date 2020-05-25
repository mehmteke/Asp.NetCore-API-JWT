using ApiWithToken.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ApiWithTokenDBContext context):base(context) {}

        public async Task AddCategoryAsync(Category category)
        {
            await context.Category.AddAsync(category);
        }

        public async Task<Category> FindByIdCategory(int categoryId)
        {
            return await context.Category.FindAsync(categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Category.ToList();
        }

        public async Task RemoveCategory(int categoryId)
        {
            Category category = await FindByIdCategory(categoryId);
            context.Category.Remove(category);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            context.Category.Update(category);
            return await FindByIdCategory(category.Id); 
        }
    }
}
