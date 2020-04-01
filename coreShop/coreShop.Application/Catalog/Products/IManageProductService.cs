using coreShop.Application.Catalog.Products.Dtos;
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
        Task<int> Update(ProductCreateRequest request);
        Task<int> Delete(int productId);
        List<ProductViewModel> GetAll();
        PagedViewModel<ProductViewModel> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}
