using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.ViewModel.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public IFormFile imageFile { get; set; }
    }
}
