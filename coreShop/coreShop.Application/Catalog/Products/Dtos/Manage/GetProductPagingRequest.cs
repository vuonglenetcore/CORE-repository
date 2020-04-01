using coreShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
