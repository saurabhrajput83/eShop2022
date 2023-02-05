using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.DAL.Repositories.Interfaces;

namespace eShop.DAL.UnitOfWork
{
    public interface IAppUnitOfWork
    {
        IBrandRepository BrandRepository { get; }
        IDepartmentProductRepository DepartmentProductRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductVariationRepository ProductVariationRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ISelectedItemRepository SelectedItemRepository { get; }
        ISelectedItemVariationRepository SelectedItemVariationRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        IVariationTypeRepository VariationTypeRepository { get; }
        IVariationRepository VariationRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
