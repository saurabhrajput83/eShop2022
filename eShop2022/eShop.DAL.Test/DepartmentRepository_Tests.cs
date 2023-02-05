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
    public class DepartmentRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly DepartmentHelper _departmentHelper;

        public DepartmentRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _departmentHelper = new DepartmentHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Department department;

            // Act
            department = _departmentHelper.Insert(Constants.DepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(department));

        }

        [TestMethod]
        public void Test2_InsertChild()
        {
            //Arrange
            Department childDepartment;

            // Act
            childDepartment = _departmentHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));

        }

        [TestMethod]
        public void Test3_GetAll()
        {
            //Arrange
            List<Department> departments;

            // Act
            departments = _unitOfWork.DepartmentRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(departments.IsNotEmpty());
        }

        [TestMethod]
        public void Test4_GetByGuid()
        {
            //Arrange
            Department department;
            Department childDepartment;

            // Act
            department = _unitOfWork.DepartmentRepository.GetByGuid(Constants.DepartmentGuid);
            childDepartment = _unitOfWork.DepartmentRepository.GetByGuid(Constants.ChildDepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(department));
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));
        }

        [TestMethod]
        public void Test5_Update()
        {
            //Arrange
            Department department;
            string newName = "New Test Department";

            // Act
            department = _unitOfWork.DepartmentRepository.GetByGuid(Constants.DepartmentGuid);
            if (department != null)
            {
                department.Name = newName;
                _unitOfWork.DepartmentRepository.Update(department);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(department) && department.Name == newName);
        }


        [TestMethod]
        public void Test6_Delete()
        {
            //Arrange
            Department childDepartment;
            Department department;


            // Act
            _departmentHelper.Delete(Constants.ChildDepartmentGuid);
            _departmentHelper.Delete(Constants.DepartmentGuid);
            _departmentHelper.CleanUp();

            childDepartment = _unitOfWork.DepartmentRepository.GetByGuid(Constants.ChildDepartmentGuid);
            department = _unitOfWork.DepartmentRepository.GetByGuid(Constants.DepartmentGuid);

            //Assert
            Assert.IsTrue(childDepartment.IsNull());
            Assert.IsTrue(department.IsNull());
        }


    }
}