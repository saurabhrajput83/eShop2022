using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace eShop.DAL.Test
{
    [TestClass]
    public class DepartmentRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly DepartmentHelper _departmentHelper;

        public DepartmentRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _departmentHelper = new DepartmentHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Department department;

            // Act
            department = await _departmentHelper.InsertAsync(Constants.DepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(department));

        }

        [TestMethod]
        public async Task Test2_InsertChild()
        {
            //Arrange
            Department childDepartment;

            // Act
            childDepartment = await _departmentHelper.InsertChildAsync(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));

        }

        [TestMethod]
        public async Task Test3_GetAll()
        {
            //Arrange
            List<Department> departments;

            // Act
            departments = await _unitOfWork.DepartmentRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(departments.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test4_GetByGuid()
        {
            //Arrange
            Department department;
            Department childDepartment;

            // Act
            department = await _unitOfWork.DepartmentRepository.GetByGuidAsync(Constants.DepartmentGuid, _token);
            childDepartment = await _unitOfWork.DepartmentRepository.GetByGuidAsync(Constants.ChildDepartmentGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(department));
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(childDepartment));
        }

        [TestMethod]
        public async Task Test5_Update()
        {
            //Arrange
            Department department;
            string newName = "New Test Department";

            // Act
            department = await _unitOfWork.DepartmentRepository.GetByGuidAsync(Constants.DepartmentGuid, _token);
            if (department != null)
            {
                department.Name = newName;
                _unitOfWork.DepartmentRepository.Update(department, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartment(department) && department.Name == newName);
        }


        [TestMethod]
        public async Task Test6_Delete()
        {
            //Arrange
            Department childDepartment;
            Department department;


            // Act
            await _departmentHelper.DeleteAsync(Constants.ChildDepartmentGuid);
            await _departmentHelper.DeleteAsync(Constants.DepartmentGuid);
            await _departmentHelper.CleanUpAsync();

            childDepartment = await _unitOfWork.DepartmentRepository.GetByGuidAsync(Constants.ChildDepartmentGuid, _token);
            department = await _unitOfWork.DepartmentRepository.GetByGuidAsync(Constants.DepartmentGuid, _token);

            //Assert
            Assert.IsTrue(childDepartment.IsNull());
            Assert.IsTrue(department.IsNull());
        }


    }
}