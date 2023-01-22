using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace eShop.BLL.Test
{
    public class DepartmentLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly DepartmentLogicHelper _departmentLogicHelper;
        
        public DepartmentLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _departmentLogicHelper = new DepartmentLogicHelper(_logicHelper);
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
            DepartmentView = _departmentLogicHelper.Insert(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView));
        }


        [Test]
        public void Test2_InsertChild()
        {
            //Arrange
            DepartmentFullView childDepartment;

            // Act
            childDepartment = _departmentLogicHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));

        }

        [Test]
        public void Test3_GetAll()
        {
            // Arrange
            List<DepartmentMinimalView> Departments;

            // Act
            Departments = _logicHelper.DepartmentLogic.GetAll();

            // Assert
            Assert.IsTrue(Departments.IsNotEmpty());
        }

        [Test]
        public void Test4_GetByGuid()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            DepartmentView = _logicHelper.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

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
            DepartmentView = _logicHelper.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            DepartmentView.Name = newDepartmentName;
            _logicHelper.DepartmentLogic.Update(DepartmentView);

            DepartmentView = _logicHelper.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(DepartmentView) && DepartmentView.Name == newDepartmentName);
        }

        [Test]
        public void Test6_Delete()
        {
            // Arrange
            DepartmentFullView DepartmentView;

            // Act
            _departmentLogicHelper.Delete(Constants.DepartmentGuid);
            _departmentLogicHelper.Delete(Constants.ChildDepartmentGuid);
            _departmentLogicHelper.CleanUp();

            DepartmentView = _logicHelper.DepartmentLogic.GetByGuid(Constants.DepartmentGuid);

            // Assert
            Assert.IsTrue(DepartmentView.IsNull());
        }
    }
}