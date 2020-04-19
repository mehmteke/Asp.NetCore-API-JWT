using ApiWithToken.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Service
{
    public interface IProductService
    {
        Task<ProductListResponse> ListAsync(); 
        Task<ProductResponse> AddProductAsync(Product product);
        Task<ProductResponse> RemoveProductAsync(int productId);
        Task<ProductResponse> UpdateProduct(Product product,int productId);
        Task<ProductResponse> FindByIdAsync(int productId); 
    }
}
