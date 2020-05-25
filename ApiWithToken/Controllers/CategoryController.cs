using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoryListResponse categoryListResponse;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            categoryListResponse = categoryService.GetCategories();
            if (categoryListResponse.Success)
            {
                return Ok(categoryListResponse.categories);
            }
            else
            {
                return BadRequest(categoryListResponse.Message);
            }
        }
    }
}