using eShop.BLL.Dtos;
using eShop.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateBrand(BrandFullView brand)
        {
            return (brand.IsNotNull() && brand.Id > 0 && brand.Guid == Constants.BrandGuid);
        }

        public static bool ValidateProduct(ProductFullView product)
        {
            return (product.IsNotNull() && product.Id > 0 && product.Guid == Constants.ProductGuid);
        }

        public static bool ValidateDepartment(DepartmentFullView department)
        {
            return (department.IsNotNull() && department.Id > 0 && department.Guid == Constants.DepartmentGuid);
        }

        public static bool ValidateChildDepartment(DepartmentFullView department)
        {
            return (department.IsNotNull() && department.Id > 0 && department.Guid == Constants.ChildDepartmentGuid);
        }

        public static bool ValidateDepartmentProduct(DepartmentProductFullView departmentProduct)
        {
            return (departmentProduct.IsNotNull() && departmentProduct.Id > 0 && departmentProduct.Guid == Constants.DepartmentProductGuid);
        }

        public static bool ValidateShoppingCart(ShoppingCartView shoppingCart)
        {
            return (shoppingCart.IsNotNull() && shoppingCart.Id > 0 && shoppingCart.Guid == Constants.ShoppingCartGuid);
        }

        public static bool ValidateSelectedItem(SelectedItemFullView selectedItem)
        {
            return (selectedItem.IsNotNull() && selectedItem.Id > 0 && selectedItem.Guid == Constants.SelectedItemGuid);
        }

        public static bool ValidateWarehouse(WarehouseFullView warehouse)
        {
            return (warehouse.IsNotNull() && warehouse.Id > 0 && warehouse.Guid == Constants.WarehouseGuid);
        }

        public static bool ValidateVariationType(VariationTypeFullView variationType)
        {
            return (variationType.IsNotNull() && variationType.Id > 0 && variationType.Guid == Constants.VariationTypeGuid);
        }

        public static bool ValidateVariation(VariationFullView variation)
        {
            return (variation.IsNotNull() && variation.Id > 0 && variation.Guid == Constants.VariationGuid);
        }

        public static bool ValidateInventory(InventoryFullView inventory)
        {
            return (inventory.IsNotNull() && inventory.Id > 0 && inventory.Guid == Constants.InventoryGuid);
        }

        public static bool ValidateReview(ReviewView review)
        {
            return (review.IsNotNull() && review.Id > 0 && review.Guid == Constants.ReviewGuid);
        }
    }
}
