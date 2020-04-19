using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Response
{
    public class ProductListResponse:BaseResponse
    {
       public IEnumerable<Product> Products { get; set; }

        private ProductListResponse(bool success, string errorMessage, IEnumerable<Product> products):base(success, errorMessage)
        {
            this.Products = products;
        }

        // Başarılı olursa
        public ProductListResponse(IEnumerable<Product> products):this(true,"",products) 
        {
        }

        // Başarısız Olursa
        public ProductListResponse(string errorMessage):this(false,errorMessage,null)
        {
        }

    }
}
