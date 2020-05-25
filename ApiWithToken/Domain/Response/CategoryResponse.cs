using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Response
{
    public class CategoryResponse: BaseResponse
    {
        public Category category { get; set; }
        private CategoryResponse(bool success, string message,Category category):base(success,message)
        {
            this.category = category;
        }
        public CategoryResponse(Category category):this(true,"",category){}
        public CategoryResponse(string errorMessage) : this(false, errorMessage, null) { }
    }
}
