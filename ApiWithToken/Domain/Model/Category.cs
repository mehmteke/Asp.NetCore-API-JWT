using System;
using System.Collections.Generic;

namespace ApiWithToken.Domain
{
    public partial class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string SeoUrl { get; set; }
    }
}
