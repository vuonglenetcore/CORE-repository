using coreShop.Application.Catalog.Products.Dtos;
using coreShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        public PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
