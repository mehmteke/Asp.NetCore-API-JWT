using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithToken.Domain;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Extensions;
using ApiWithToken.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductResponse ProductResponse { get; private set; }

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ProductListResponse productListResponse = await productService.ListAsync();

            if (productListResponse.Success) {
                return Ok(productListResponse.Products);
            }
            else {
                return BadRequest(productListResponse.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            ProductResponse productResponse = await productService.FindByIdAsync(id);

            if (productResponse.Success) {
                return Ok(productResponse.product);
            }
            else {
                return BadRequest(productResponse.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductResource productResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrors());
            }
            else {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                ProductResponse productResponse = await productService.AddProductAsync(product);

                if (productResponse.Success) {
                    return Ok(productResponse.product);
                }
                else {
                    return BadRequest(productResponse.Message);
                } 
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource, int productId)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrors());
            }
            else {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                ProductResponse productResponse = await productService.UpdateProduct(product, productId);

                if (productResponse.Success) {
                    return Ok(productResponse.product);
                }
                else {
                    return BadRequest(productResponse.Message);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            ProductResponse productResponse = await productService.RemoveProductAsync(id);

            if (productResponse.Success) {
                return Ok(productResponse.product);
            }else {
                return BadRequest(productResponse.Message);
            }
        }

    }
}