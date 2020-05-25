using ApiWithToken.Domain;
using ApiWithToken.Domain.Repositories.Interface;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> AddCategoryAsync(Category category)
        {
            try
            {
                await categoryRepository.AddCategoryAsync(category);
                await unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse("Category Eklenirken Hata Alındı : Hata " + ex.Message.ToString());
                throw;
            }
        }

        public async Task<CategoryResponse> FindByIdCategory(int categoryId)
        {
            try
            {
               Category category = await categoryRepository.FindByIdCategory(categoryId);
                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse("Kategory Bulunurken Hata Alındı : " + ex.Message.ToString());
                throw;
            }
        }

        public CategoryListResponse GetCategories()
        {
            IEnumerable<Category> categories;
            try
            {
                categories = categoryRepository.GetCategories();
                return new CategoryListResponse(categories);
            }
            catch (Exception ex)
            {
                return new CategoryListResponse("Kategory Listesi Alınırken Hata Alındı : " + ex.Message.ToString());
                throw;
            }
        }

        public async Task<CategoryResponse> RemoveCategory(int categoryId)
        {
            try
            {
                Category category = await categoryRepository.FindByIdCategory(categoryId);
                await categoryRepository.RemoveCategory(categoryId);
                await unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse("Kategori Eklenirken Hata ALındı:" + ex.Message.ToString());
                throw;
            }
        }

        public Task<CategoryResponse> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
