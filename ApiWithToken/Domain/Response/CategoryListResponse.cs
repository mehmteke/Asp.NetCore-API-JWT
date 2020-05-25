using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Response
{
    public class CategoryListResponse:BaseResponse
    {
        public IEnumerable<Category> categories { get; set; }
        public CategoryListResponse(bool success, string message,IEnumerable<Category> categories):base(success,message)
        {
            this.categories = categories;
        }

        public CategoryListResponse(IEnumerable<Category> categories) : this(true, "", categories) { }
        public CategoryListResponse(string errorMessage) : this(false, errorMessage, null) { }
    }
}
