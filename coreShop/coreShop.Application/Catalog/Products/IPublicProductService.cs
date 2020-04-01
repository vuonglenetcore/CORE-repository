using coreShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.Application.Catalog.Products.Dtos
{
    public interface IPublicProductService
    {
        PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId,int pageIndex, int pageSize);
    }
}
