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
        private readonly CancellationToken _token;
        private readonly SelectedItemHelper _selectedItemHelper;

        public SelectedItemRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _selectedItemHelper = new SelectedItemHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            SelectedItem selectedItem;

            // Act
            selectedItem = await _selectedItemHelper.InsertAsync(Constants.SelectedItemGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItem));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<SelectedItem> selectedItems;

            // Act
            selectedItems = await _unitOfWork.SelectedItemRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(selectedItems.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            SelectedItem selectedItem;

            // Act
            selectedItem = await _unitOfWork.SelectedItemRepository.GetByGuidAsync(Constants.SelectedItemGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItem));
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(selectedItem.ShoppingCart));
            Assert.IsTrue(ValidationHelper.ValidateProduct(selectedItem.Product));
        }

        //[TestMethod]
        //public void Test4_GetByShoppingCartGuid()
        //{
        //    //Arrange
        //    List<SelectedItem> selectedItems;

        //    // Act
        //    selectedItems = _unitOfWork.SelectedItemRepository.GetByShoppingCartGuid(Constants.ShoppingCartGuid).ToList();

        //    //Assert
        //    Assert.IsTrue(selectedItems.IsNotEmpty());
        //}

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
        public async Task Test5_Delete()
        {
            //Arrange
            SelectedItem selectedItem;

            // Act
            await _selectedItemHelper.DeleteAsync(Constants.SelectedItemGuid);
            await _selectedItemHelper.CleanUpAsync();

            selectedItem = await _unitOfWork.SelectedItemRepository.GetByGuidAsync(Constants.SelectedItemGuid, _token);

            //Assert
            Assert.IsTrue(selectedItem.IsNull());
        }


    }
}