using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using eShop.BLL.Services;

namespace eShop.BLL.Test
{
    public class DepartmentLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly DepartmentLogicHelper _departmentLogicHelper;

        public DepartmentLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _departmentLogicHelper = new DepartmentLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            DepartmentView = await _departmentLogicHelper.InsertAsync(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView));
        }


        [Test]
        public async Task Test2_InsertChild()
        {
            //Arrange
            DepartmentFullView childDepartment;

            // Act
            childDepartment = await _departmentLogicHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));

        }

        [Test]
        public async Task Test3_GetAll()
        {
            // Arrange
            List<DepartmentMinimalView> Departments;

            // Act
            Departments = await _appServices.DepartmentLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(Departments.IsNotEmpty());
        }

        [Test]
        public async Task Test4_GetByGuid()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            DepartmentView = await _appServices.DepartmentLogic.GetByGuidAsync(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView));
        }

        [Test]
        public async Task Test5_Update()
        {
            // Arrange
            string newDepartmentName = "Test New Department Name";
            DepartmentFullView DepartmentView;


            // Act
            DepartmentView = await _appServices.DepartmentLogic.GetByGuidAsync(Constants.DepartmentGuid);

            DepartmentView.Name = newDepartmentName;
            await _appServices.DepartmentLogic.UpdateAsync(DepartmentView);

            DepartmentView = await _appServices.DepartmentLogic.GetByGuidAsync(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView) && DepartmentView.Name == newDepartmentName);
        }

        [Test]
        public async Task Test6_Delete()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            await _departmentLogicHelper.DeleteAsync(Constants.DepartmentGuid);
            await _departmentLogicHelper.DeleteAsync(Constants.ChildDepartmentGuid);
            await _departmentLogicHelper.CleanUpAsync();

            DepartmentView = await _appServices.DepartmentLogic.GetByGuidAsync(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(DepartmentView.IsNull());
        }
    }
}