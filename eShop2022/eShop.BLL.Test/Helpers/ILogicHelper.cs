using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Interfaces;
using eShop.DAL.Infrastructure;

namespace eShop.BLL.Test.Helpers
{
    public interface ILogicHelper
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
