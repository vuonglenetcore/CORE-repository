using coreShop.ViewModel.Catalog.Products;
using coreShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.Application.Catalog.Products.Dtos
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
    }
}
