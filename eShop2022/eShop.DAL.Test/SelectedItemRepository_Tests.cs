using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Test
{
    [TestClass]
    public class SelectedItemRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly SelectedItemHelper _selectedItemHelper;

        public SelectedItemRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _selectedItemHelper = new SelectedItemHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            SelectedItem selectedItem;

            // Act
            selectedItem = _selectedItemHelper.Insert(Constants.SelectedItemGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItem));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<SelectedItem> selectedItems;

            // Act
            selectedItems = _unitOfWork.SelectedItemRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(selectedItems.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            SelectedItem selectedItem;

            // Act
            selectedItem = _unitOfWork.SelectedItemRepository.GetByGuid(Constants.SelectedItemGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItem));
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(selectedItem.ShoppingCart));
            Assert.IsTrue(ValidationHelper.ValidateProduct(selectedItem.Product));
        }

        [TestMethod]
        public void Test4_GetByShoppingCartGuid()
        {
            //Arrange
            List<SelectedItem> selectedItems;

            // Act
            selectedItems = _unitOfWork.SelectedItemRepository.GetByShoppingCartGuid(Constants.ShoppingCartGuid).ToList();

            //Assert
            Assert.IsTrue(selectedItems.IsNotEmpty());
        }

        //[TestMethod]
        //public void Test4_Update()
        //{
        //    //Arrange
        //    SelectedItem selectedItem;
        //    string newName = "New Test SelectedItem";

        //    // Act
        //    selectedItem = _unitOfWork.SelectedItemRepository.GetByGuid(_selectedItemGuid);
        //    if (selectedItem != null)
        //    {
        //        selectedItem.Name = newName;
        //        _unitOfWork.SelectedItemRepository.Update(selectedItem);
        //        _unitOfWork.Save();
        //    }

        //    //Assert
        //    Assert.IsTrue(selectedItem != null && selectedItem.Id > 0 && selectedItem.Name == newName);
        //}


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            SelectedItem selectedItem;

            // Act
            _selectedItemHelper.Delete(Constants.SelectedItemGuid);
            _selectedItemHelper.CleanUp();

            selectedItem = _unitOfWork.SelectedItemRepository.GetByGuid(Constants.SelectedItemGuid);

            //Assert
            Assert.IsTrue(selectedItem.IsNull());
        }


    }
}