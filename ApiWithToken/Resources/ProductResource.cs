using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Resources
{
    public class ProductResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }

        /*
          Client tarafında JSON olarak gelen nesneyi bu obje ye cast etmek için Resource nesnelerimizi oluşturduk.
          {"Name":"Mehmet","Category":"Şirket","Price":"1254"}
        */
    }
}
