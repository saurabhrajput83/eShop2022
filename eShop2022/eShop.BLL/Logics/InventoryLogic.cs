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
    public class InventoryLogic : IInventoryLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<InventoryLogic> _logger;


        public InventoryLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<InventoryLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid inventoryGuid)
        {
            try
            {
                Inventory inventoryEntity = await _unitOfWork.InventoryRepository.GetByGuidAsync(inventoryGuid, _token);
                if (inventoryEntity.IsNotNull())
                {
                    _unitOfWork.InventoryRepository.Delete(inventoryEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.Delete");
                throw;
            }
        }

        public async Task<List<InventoryMinimalView>> GetAllAsync()
        {
            try
            {
                List<Inventory> result = await _unitOfWork.InventoryRepository.GetAllAsync(_token);
                return _mapper.Map<List<InventoryMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.GetAll");
                throw;
            }
        }

        public async Task<InventoryFullView> GetByGuidAsync(Guid inventoryGuid)
        {
            try
            {
                Inventory inventoryEntity = await _unitOfWork.InventoryRepository.GetByGuidAsync(inventoryGuid, _token);
                return _mapper.Map<InventoryFullView>(inventoryEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.inventoryGuid");
                throw;
            }
        }

        public async Task<InventoryFullView> InsertAsync(InventoryFullView inventoryView)
        {
            try
            {
                Inventory inventoryEntity = _mapper.Map<Inventory>(inventoryView);
                await _unitOfWork.InventoryRepository.InsertAsync(inventoryEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<InventoryFullView>(inventoryEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(InventoryFullView inventoryView)
        {
            try
            {
                Inventory inventoryEntity = await _unitOfWork.InventoryRepository.GetByGuidAsync(inventoryView.Guid, _token);
                inventoryEntity = _mapper.Map<InventoryFullView, Inventory>(inventoryView, inventoryEntity);
                _unitOfWork.InventoryRepository.Update(inventoryEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.Update");
                throw;
            }
        }
    }
}
