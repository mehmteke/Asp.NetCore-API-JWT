using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Response
{
    public class ProductResponse: BaseResponse
    {
        public Product product { get; set; }
        private ProductResponse(bool success, string errorMessage, Product product):base(success, errorMessage)
        {
            this.product = product;
        }

        // Başarılı Olursa.
        public ProductResponse(Product product):this(true,"",product)
        {
        }

        // Başarısız Olursa.
        public ProductResponse(string errorMessage):this(false,errorMessage,null)
        {
        }
    }
}
