using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using eShop.BLL.Services;

namespace eShop.BLL.Test
{
    public class SelectedItemLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly SelectedItemLogicHelper _selectedItemLogicHelper;

        public SelectedItemLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _selectedItemLogicHelper = new SelectedItemLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            SelectedItemFullView selectedItemView;

            // Act
            selectedItemView = await _selectedItemLogicHelper.InsertAsync(Constants.SelectedItemGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItemView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<SelectedItemMinimalView> selectedItems;

            // Act
            selectedItems = await _appServices.SelectedItemLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(selectedItems.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuidAsync()
        {
            // Arrange
            SelectedItemFullView selectedItemView;

            // Act
            selectedItemView = await _appServices.SelectedItemLogic.GetByGuidAsync(Constants.SelectedItemGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItemView));
        }

        //[Test]
        //public async Task Test4_Update()
        //{
        //    // Arrange
        //    string newSelectedItemName = "Test New SelectedItem Name";
        //    SelectedItemFullView selectedItemView;


        //    // Act
        //    selectedItemView = _appServices.SelectedItemLogic.GetByGuidAsync(Constants.SelectedItemGuid);

        //    selectedItemView.Name = newSelectedItemName;
        //    _appServices.SelectedItemLogic.Update(selectedItemView);

        //    selectedItemView = _appServices.SelectedItemLogic.GetByGuidAsync(Constants.SelectedItemGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItemView) && selectedItemView.Name == newSelectedItemName);
        //}

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            SelectedItemFullView selectedItemView;

            // Act
            await _selectedItemLogicHelper.DeleteAsync(Constants.SelectedItemGuid);
            await _selectedItemLogicHelper.CleanUpAsync();

            selectedItemView = await _appServices.SelectedItemLogic.GetByGuidAsync(Constants.SelectedItemGuid);

            // Assert
            Assert.IsTrue(selectedItemView.IsNull());
        }
    }
}