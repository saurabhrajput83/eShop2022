using eShop.BLL.Dtos;
using eShop.DAL.Entities;
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
        public static bool ValidateBrand(BrandView brandView)
        {
            return (brandView.IsNotNull() && brandView.Id > 0 && brandView.Guid == Constants.BrandGuid);
        }

        //public static bool ValidateProduct(Product product)
        //{
        //    return (product.IsNotNull() && product.Id > 0 && product.Guid == Constants.ProductGuid);
        //}

        //public static bool ValidateDepartment(Department department)
        //{
        //    return (department.IsNotNull() && department.Id > 0 && department.Guid == Constants.DepartmentGuid);
        //}

        //public static bool ValidateChildDepartment(Department department)
        //{
        //    return (department.IsNotNull() && department.Id > 0 && department.Guid == Constants.ChildDepartmentGuid
        //        && ValidateDepartment(department.Parent));
        //}

        //public static bool ValidateDepartmentProduct(DepartmentProduct departmentProduct)
        //{
        //    return (departmentProduct.IsNotNull() && departmentProduct.Id > 0 && departmentProduct.Guid == Constants.DepartmentProductGuid);
        //}

        //public static bool ValidateShoppingCart(ShoppingCart shoppingCart)
        //{
        //    return (shoppingCart.IsNotNull() && shoppingCart.Id > 0 && shoppingCart.Guid == Constants.ShoppingCartGuid);
        //}

        //public static bool ValidateSelectedItem(SelectedItem selectedItem)
        //{
        //    return (selectedItem.IsNotNull() && selectedItem.Id > 0 && selectedItem.Guid == Constants.SelectedItemGuid);
        //}

        //public static bool ValidateWarehouse(Warehouse warehouse)
        //{
        //    return (warehouse.IsNotNull() && warehouse.Id > 0 && warehouse.Guid == Constants.WarehouseGuid);
        //}

        //public static bool ValidateVariationType(VariationType variationType)
        //{
        //    return (variationType.IsNotNull() && variationType.Id > 0 && variationType.Guid == Constants.VariationTypeGuid);
        //}

        //public static bool ValidateVariation(Variation variation)
        //{
        //    return (variation.IsNotNull() && variation.Id > 0 && variation.Guid == Constants.VariationGuid);
        //}

        //public static bool ValidateInventory(Inventory inventory)
        //{
        //    return (inventory.IsNotNull() && inventory.Id > 0 && inventory.Guid == Constants.InventoryGuid);
        //}

        //public static bool ValidateReview(Review review)
        //{
        //    return (review.IsNotNull() && review.Id > 0 && review.Guid == Constants.ReviewGuid);
        //}
    }
}
