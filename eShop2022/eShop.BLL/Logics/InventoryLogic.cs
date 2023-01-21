using AutoMapper;
using AutoMapper.Internal;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<InventoryLogic> _logger;


        public InventoryLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<InventoryLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid inventoryGuid)
        {
            try
            {
                Inventory inventoryEntity = _unitOfWork.InventoryRepository.GetByGuid(inventoryGuid);
                if (inventoryEntity.IsNotNull())
                {
                    inventoryEntity = _unitOfWork.InventoryRepository.Delete(inventoryEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.Delete");
                throw;
            }
        }

        public List<InventoryMinimalView> GetAll()
        {
            try
            {
                List<Inventory> result = _unitOfWork.InventoryRepository.GetAll().ToList();
                return _mapper.Map<List<InventoryMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.GetAll");
                throw;
            }
        }

        public InventoryFullView GetByGuid(Guid inventoryGuid)
        {
            try
            {
                Inventory inventoryEntity = _unitOfWork.InventoryRepository.GetByGuid(inventoryGuid);
                return _mapper.Map<InventoryFullView>(inventoryEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.inventoryGuid");
                throw;
            }
        }

        public InventoryFullView Insert(InventoryFullView inventoryView)
        {
            try
            {
                Inventory inventoryEntity = _mapper.Map<Inventory>(inventoryView);
                inventoryEntity = _unitOfWork.InventoryRepository.Insert(inventoryEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<InventoryFullView>(inventoryEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.Insert");
                throw;
            }
        }

        public void Update(InventoryFullView inventoryView)
        {
            try
            {
                Inventory inventoryEntity = _mapper.Map<InventoryFullView, Inventory>(inventoryView);
                _unitOfWork.InventoryRepository.Update(inventoryEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InventoryLogic.Update");
                throw;
            }
        }
    }
}
