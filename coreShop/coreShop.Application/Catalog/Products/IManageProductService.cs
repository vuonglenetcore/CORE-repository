using coreShop.Application.Catalog.Products.Dtos;
using coreShop.Application.Catalog.Products.Dtos.Manage;
using coreShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<int> UpdatePrice(int productId, decimal newPrice);
        Task<int> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
