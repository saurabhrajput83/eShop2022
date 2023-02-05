using AutoMapper;
using AutoMapper.Internal;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using eShop.DAL.UnitOfWork;
using eShop.Infrastructure;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Logics
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentLogic> _logger;


        public DepartmentLogic(IeShopUnitOfWork unitOfWork, IMapper mapper, ILogger<DepartmentLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid departmentGuid)
        {
            try
            {
                Department departmentEntity = _unitOfWork.DepartmentRepository.GetByGuid(departmentGuid);
                if (departmentEntity.IsNotNull())
                {
                    _unitOfWork.DepartmentRepository.Delete(departmentEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.Delete");
                throw;
            }
        }

        public List<DepartmentMinimalView> GetAll()
        {
            try
            {
                List<Department> result = _unitOfWork.DepartmentRepository.GetAll().ToList();
                return _mapper.Map<List<DepartmentMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.GetAll");
                throw;
            }
        }

        public DepartmentFullView GetByGuid(Guid departmentGuid)
        {
            try
            {
                Department departmentEntity = _unitOfWork.DepartmentRepository.GetByGuid(departmentGuid);
                return _mapper.Map<DepartmentFullView>(departmentEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.departmentGuid");
                throw;
            }
        }

        public DepartmentFullView Insert(DepartmentFullView departmentView)
        {
            try
            {
                Department departmentEntity = _mapper.Map<Department>(departmentView);
                _unitOfWork.DepartmentRepository.Insert(departmentEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<DepartmentFullView>(departmentEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.Insert");
                throw;
            }
        }

        public void Update(DepartmentFullView departmentView)
        {
            try
            {
                Department departmentEntity = _mapper.Map<DepartmentFullView, Department>(departmentView);
                _unitOfWork.DepartmentRepository.Update(departmentEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.Update");
                throw;
            }
        }
    }
}
