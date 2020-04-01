using coreShop.Application.Catalog.Products.Dtos;
using coreShop.Application.Catalog.Products.Dtos.Public;
using coreShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.Application.Catalog.Products.Dtos
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
