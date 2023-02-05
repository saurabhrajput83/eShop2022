using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Logics.Interfaces;


namespace eShop.BLL.Services
{
    public interface IAppServices
    {
        IBrandLogic BrandLogic { get; }
        IDepartmentProductLogic DepartmentProductLogic { get; }
        IDepartmentLogic DepartmentLogic { get; }
        IInventoryLogic InventoryLogic { get; }
        IProductImageLogic ProductImageLogic { get; }
        IProductLogic ProductLogic { get; }
        IProductVariationLogic ProductVariationLogic { get; }
        IReviewLogic ReviewLogic { get; }
        ISelectedItemLogic SelectedItemLogic { get; }
        //ISelectedItemVariationLogic SelectedItemVariationLogic { get; }
        IShoppingCartLogic ShoppingCartLogic { get; }
        IVariationTypeLogic VariationTypeLogic { get; }
        IVariationLogic VariationLogic { get; }
        IWarehouseLogic WarehouseLogic { get; }
    }
}
