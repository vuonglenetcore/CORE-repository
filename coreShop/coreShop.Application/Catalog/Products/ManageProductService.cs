using coreShop.Application.Catalog.Products.Dtos;
using coreShop.Application.Dtos;
using coreShop.Data.EF;
using coreShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly coreShopDbContext _context;
        public ManageProductService(coreShopDbContext context)
        {
            _context = context;
        }


        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
            };
            _context.products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public Task<int> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PagedViewModel<ProductViewModel> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
