using coreShop.ViewModel.Catalog.ProductImages;
using coreShop.ViewModel.Catalog.Products;
using coreShop.ViewModel.Common;
using Microsoft.AspNetCore.Http;
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
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<int> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<int> AddImages(int productId, ProductImageCreateRequest productImage);

        Task<int> RemoveImages(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest productImage);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
        Task<ProductImageViewModel> GetImageById(int imageId);
    }
}
