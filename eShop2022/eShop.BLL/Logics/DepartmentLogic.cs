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
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentLogic> _logger;


        public DepartmentLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<DepartmentLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid departmentGuid)
        {
            try
            {
                Department departmentEntity = await _unitOfWork.DepartmentRepository.GetByGuidAsync(departmentGuid, _token);
                if (departmentEntity.IsNotNull())
                {
                    _unitOfWork.DepartmentRepository.Delete(departmentEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.Delete");
                throw;
            }
        }

        public async Task<List<DepartmentMinimalView>> GetAllAsync()
        {
            try
            {
                List<Department> result = await _unitOfWork.DepartmentRepository.GetAllAsync(_token);
                return _mapper.Map<List<DepartmentMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.GetAll");
                throw;
            }
        }

        public async Task<DepartmentFullView> GetByGuidAsync(Guid departmentGuid)
        {
            try
            {
                Department departmentEntity = await _unitOfWork.DepartmentRepository.GetByGuidAsync(departmentGuid, _token);
                return _mapper.Map<DepartmentFullView>(departmentEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.departmentGuid");
                throw;
            }
        }

        public async Task<DepartmentFullView> InsertAsync(DepartmentFullView departmentView)
        {
            try
            {
                Department departmentEntity = _mapper.Map<Department>(departmentView);
                await _unitOfWork.DepartmentRepository.InsertAsync(departmentEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<DepartmentFullView>(departmentEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(DepartmentFullView departmentView)
        {
            try
            {
                Department departmentEntity = await _unitOfWork.DepartmentRepository.GetByGuidAsync(departmentView.Guid, _token);
                departmentEntity = _mapper.Map<DepartmentFullView, Department>(departmentView, departmentEntity);
                _unitOfWork.DepartmentRepository.Update(departmentEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepartmentLogic.Update");
                throw;
            }
        }
    }
}
