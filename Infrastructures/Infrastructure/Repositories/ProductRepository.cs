using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.ProductRef;
using ApplicationDomain.ReferenceData.ProductRef.Requests;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable List(ListProductRequest requestData)
        {
            return this.dbSet.Where(p => p.MenuId == requestData.MenuId && p.Category == requestData.Category &&
            (string.IsNullOrEmpty(requestData.SearchTerm) || p.Name.Contains(requestData.SearchTerm)) &&
            (requestData.SubCategories.Count == 0 || requestData.SubCategories.Contains(p.SubCategory)));
        }

        public async Task<List<Product>> GetProductsByMenu(int menuId)
        {
            return await this.dbSet.Where(p => p.MenuId == menuId).ToListAsync();
        }
    }
}
