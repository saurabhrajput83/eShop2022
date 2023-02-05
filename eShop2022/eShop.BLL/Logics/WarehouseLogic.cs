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
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<WarehouseLogic> _logger;


        public WarehouseLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<WarehouseLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid warehouseGuid)
        {
            try
            {
                Warehouse warehouseEntity = await _unitOfWork.WarehouseRepository.GetByGuidAsync(warehouseGuid, _token);
                if (warehouseEntity.IsNotNull())
                {
                    _unitOfWork.WarehouseRepository.Delete(warehouseEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.Delete");
                throw;
            }
        }

        public async Task<List<WarehouseMinimalView>> GetAllAsync()
        {
            try
            {
                List<Warehouse> result = await _unitOfWork.WarehouseRepository.GetAllAsync(_token);
                return _mapper.Map<List<WarehouseMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.GetAll");
                throw;
            }
        }

        public async Task<WarehouseFullView> GetByGuidAsync(Guid warehouseGuid)
        {
            try
            {
                Warehouse warehouseEntity = await _unitOfWork.WarehouseRepository.GetByGuidAsync(warehouseGuid, _token);
                return _mapper.Map<WarehouseFullView>(warehouseEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.warehouseGuid");
                throw;
            }
        }

        public async Task<WarehouseFullView> InsertAsync(WarehouseFullView warehouseView)
        {
            try
            {
                Warehouse warehouseEntity = _mapper.Map<Warehouse>(warehouseView);
                await _unitOfWork.WarehouseRepository.InsertAsync(warehouseEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<WarehouseFullView>(warehouseEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(WarehouseFullView warehouseView)
        {
            try
            {
                Warehouse warehouseEntity = await _unitOfWork.WarehouseRepository.GetByGuidAsync(warehouseView.Guid, _token);
                warehouseEntity = _mapper.Map<WarehouseFullView, Warehouse>(warehouseView, warehouseEntity);
                _unitOfWork.WarehouseRepository.Update(warehouseEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.Update");
                throw;
            }
        }
    }
}
