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
        private readonly DepartmentLogicHelper _DepartmentLogicHelper;
        
        public DepartmentLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _DepartmentLogicHelper = new DepartmentLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            DepartmentView = _DepartmentLogicHelper.Insert(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView));
        }


        [Test]
        public void Test2_InsertChild()
        {
            //Arrange
            DepartmentFullView childDepartment;

            // Act
            childDepartment = _DepartmentLogicHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));

        }

        [Test]
        public void Test3_GetAll()
        {
            // Arrange
            List<DepartmentMinimalView> Departments;

            // Act
            Departments = _appServices.DepartmentLogic.GetAll();

            // Assert
            Assert.IsTrue(Departments.IsNotEmpty());
        }

        [Test]
        public void Test4_GetByGuid()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            DepartmentView = _appServices.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView));
        }

        [Test]
        public void Test5_Update()
        {
            // Arrange
            string newDepartmentName = "Test New Department Name";
            DepartmentFullView DepartmentView;


            // Act
            DepartmentView = _appServices.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            DepartmentView.Name = newDepartmentName;
            _appServices.DepartmentLogic.Update(DepartmentView);

            DepartmentView = _appServices.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView) && DepartmentView.Name == newDepartmentName);
        }

        [Test]
        public void Test6_Delete()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            _DepartmentLogicHelper.Delete(Constants.DepartmentGuid);
            _DepartmentLogicHelper.Delete(Constants.ChildDepartmentGuid);
            _DepartmentLogicHelper.CleanUp();

            DepartmentView = _appServices.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(DepartmentView.IsNull());
        }
    }
}