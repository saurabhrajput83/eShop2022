using AutoMapper;
using AutoMapper.Internal;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
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
    public class DepartmentProductLogic : IDepartmentProductLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentProductLogic> _logger;


        public DepartmentProductLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<DepartmentProductLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid departmentProductGuid)
        {
            try
            {
                DepartmentProduct departmentProductEntity = _unitOfWork.DepartmentProductRepository.GetByGuid(departmentProductGuid);
                if (departmentProductEntity.IsNotNull())
                {
                    _unitOfWork.DepartmentProductRepository.Delete(departmentProductEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.Delete");
                throw;
            }
        }

        public List<DepartmentProductMinimalView> GetAll()
        {
            try
            {
                List<DepartmentProduct> result = _unitOfWork.DepartmentProductRepository.GetAll().ToList();
                return _mapper.Map<List<DepartmentProductMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.GetAll");
                throw;
            }
        }

        public DepartmentProductFullView GetByGuid(Guid departmentProductGuid)
        {
            try
            {
                DepartmentProduct departmentProductEntity = _unitOfWork.DepartmentProductRepository.GetByGuid(departmentProductGuid);
                return _mapper.Map<DepartmentProductFullView>(departmentProductEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.departmentProductGuid");
                throw;
            }
        }

        public DepartmentProductFullView Insert(DepartmentProductFullView departmentProductView)
        {
            try
            {
                DepartmentProduct departmentProductEntity = _mapper.Map<DepartmentProduct>(departmentProductView);
                _unitOfWork.DepartmentProductRepository.Insert(departmentProductEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<DepartmentProductFullView>(departmentProductEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.Insert");
                throw;
            }
        }

        public void Update(DepartmentProductFullView departmentProductView)
        {
            try
            {
                DepartmentProduct departmentProductEntity = _mapper.Map<DepartmentProductFullView, DepartmentProduct>(departmentProductView);
                _unitOfWork.DepartmentProductRepository.Update(departmentProductEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.Update");
                throw;
            }
        }
    }
}
