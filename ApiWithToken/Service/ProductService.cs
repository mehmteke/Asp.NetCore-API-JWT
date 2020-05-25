using ApiWithToken.Domain;
using ApiWithToken.Domain.Repositories;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(ApiWithTokenDBContext context,IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<ProductResponse> AddProductAsync(Product product)
        {
            try{
                await productRepository.AddProductAsync(product);
                await unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex) {
                return new ProductResponse($"Ürün eklenirken alınan Hata : {ex.Message.ToString()}");
            } 
        }

        public async Task<ProductListResponse> FindByCategoryIdAsync(int categoryId)
        {
            try
            {
               IEnumerable<Product> products  = await productRepository.FindByCategoryIdAsync(categoryId);
                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {
                return new ProductListResponse("Kategoriye Ait Ürün alınırken hata oluştu: " + ex.Message.ToString());
                throw;
            }
        }

        public async Task<ProductResponse> FindByIdAsync(int productId)
        {
            try
            {
               Product product =  await productRepository.FindByIdAsync(productId);
               if(product == null){
                    return new ProductResponse($"{productId} Id'li ürün bulunamadı.");
                }
                else {
                    return new ProductResponse(product);
                }
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün ararken alınan hata : {ex.Message.ToString()}");
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();
                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {
                return new ProductListResponse($"Ürün Listelenirken Alınan Hata : ${ex.Message.ToString()}");
            }
        }

        public async Task<ProductResponse> RemoveProductAsync(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);

                await productRepository.RemoveProductAsync(productId);
                await unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün Silerken Alınan Hata : {ex.Message.ToString()}");
            }
        }

        public async Task<ProductResponse> UpdateProduct(Product product, int productId)
        {
            try
            {
                Product productOld = await productRepository.FindByIdAsync(productId);

                if(productOld == null) {
                    return new ProductResponse($"Güncelleenecek Ürün Bulunamadı");
                }

                productOld.ProductName = product.ProductName;
                productOld.UnitPrice = product.UnitPrice;
                productOld.CategoryId = product.CategoryId;
                productRepository.UpdateProduct(productOld);
                await unitOfWork.CompleteAsync();

                return new ProductResponse(productOld);
            }
            catch (Exception ex) {
                return new ProductResponse($"Ürün GÜncellenirken Hata Alındı: {ex.Message.ToString()}");
            }
        }
    }
}
