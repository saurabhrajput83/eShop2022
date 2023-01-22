using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace eShop.BLL.Test
{
    public class SelectedItemLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly SelectedItemLogicHelper _selectedItemLogicHelper;
        
        public SelectedItemLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _selectedItemLogicHelper = new SelectedItemLogicHelper(_logicHelper);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            SelectedItemFullView selectedItemView;

            // Act
            selectedItemView = _selectedItemLogicHelper.Insert(Constants.SelectedItemGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItemView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<SelectedItemMinimalView> selectedItems;

            // Act
            selectedItems = _logicHelper.SelectedItemLogic.GetAll();

            // Assert
            Assert.IsTrue(selectedItems.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            SelectedItemFullView selectedItemView;

            // Act
            selectedItemView = _logicHelper.SelectedItemLogic.GetByGuid(Constants.SelectedItemGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItemView));
        }

        //[Test]
        //public void Test4_Update()
        //{
        //    // Arrange
        //    string newSelectedItemName = "Test New SelectedItem Name";
        //    SelectedItemFullView selectedItemView;


        //    // Act
        //    selectedItemView = _logicHelper.SelectedItemLogic.GetByGuid(Constants.SelectedItemGuid);

        //    selectedItemView.Name = newSelectedItemName;
        //    _logicHelper.SelectedItemLogic.Update(selectedItemView);

        //    selectedItemView = _logicHelper.SelectedItemLogic.GetByGuid(Constants.SelectedItemGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateSelectedItem(selectedItemView) && selectedItemView.Name == newSelectedItemName);
        //}

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            SelectedItemFullView selectedItemView;

            // Act
            _selectedItemLogicHelper.Delete(Constants.SelectedItemGuid);
            _selectedItemLogicHelper.CleanUp();

            selectedItemView = _logicHelper.SelectedItemLogic.GetByGuid(Constants.SelectedItemGuid);

            // Assert
            Assert.IsTrue(selectedItemView.IsNull());
        }
    }
}