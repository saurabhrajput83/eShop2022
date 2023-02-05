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
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentProductLogic> _logger;


        public DepartmentProductLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<DepartmentProductLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid departmentProductGuid)
        {
            try
            {
                DepartmentProduct departmentProductEntity = await _unitOfWork.DepartmentProductRepository.GetByGuidAsync(departmentProductGuid, _token);
                if (departmentProductEntity.IsNotNull())
                {
                    _unitOfWork.DepartmentProductRepository.Delete(departmentProductEntity, _token);
                    _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.Delete");
                throw;
            }
        }

        public async Task<List<DepartmentProductMinimalView>> GetAllAsync()
        {
            try
            {
                List<DepartmentProduct> result = await _unitOfWork.DepartmentProductRepository.GetAllAsync(_token);
                return _mapper.Map<List<DepartmentProductMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.GetAll");
                throw;
            }
        }

        public async Task<DepartmentProductFullView> GetByGuidAsync(Guid departmentProductGuid)
        {
            try
            {
                DepartmentProduct departmentProductEntity = await _unitOfWork.DepartmentProductRepository.GetByGuidAsync(departmentProductGuid, _token);
                return _mapper.Map<DepartmentProductFullView>(departmentProductEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.departmentProductGuid");
                throw;
            }
        }

        public async Task<DepartmentProductFullView> InsertAsync(DepartmentProductFullView departmentProductView)
        {
            try
            {
                DepartmentProduct departmentProductEntity = _mapper.Map<DepartmentProduct>(departmentProductView);
                await _unitOfWork.DepartmentProductRepository.InsertAsync(departmentProductEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<DepartmentProductFullView>(departmentProductEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(DepartmentProductFullView departmentProductView)
        {
            try
            {
                DepartmentProduct departmentProductEntity = _mapper.Map<DepartmentProductFullView, DepartmentProduct>(departmentProductView);
                _unitOfWork.DepartmentProductRepository.Update(departmentProductEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentProductLogic.Update");
                throw;
            }
        }
    }
}
