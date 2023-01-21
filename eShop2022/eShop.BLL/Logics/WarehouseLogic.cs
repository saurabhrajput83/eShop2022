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
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<WarehouseLogic> _logger;


        public WarehouseLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<WarehouseLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid warehouseGuid)
        {
            try
            {
                Warehouse warehouseEntity = _unitOfWork.WarehouseRepository.GetByGuid(warehouseGuid);
                if (warehouseEntity.IsNotNull())
                {
                    warehouseEntity = _unitOfWork.WarehouseRepository.Delete(warehouseEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.Delete");
                throw;
            }
        }

        public List<WarehouseMinimalView> GetAll()
        {
            try
            {
                List<Warehouse> result = _unitOfWork.WarehouseRepository.GetAll().ToList();
                return _mapper.Map<List<WarehouseMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.GetAll");
                throw;
            }
        }

        public WarehouseFullView GetByGuid(Guid warehouseGuid)
        {
            try
            {
                Warehouse warehouseEntity = _unitOfWork.WarehouseRepository.GetByGuid(warehouseGuid);
                return _mapper.Map<WarehouseFullView>(warehouseEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.warehouseGuid");
                throw;
            }
        }

        public WarehouseFullView Insert(WarehouseFullView warehouseView)
        {
            try
            {
                Warehouse warehouseEntity = _mapper.Map<Warehouse>(warehouseView);
                warehouseEntity = _unitOfWork.WarehouseRepository.Insert(warehouseEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<WarehouseFullView>(warehouseEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.Insert");
                throw;
            }
        }

        public void Update(WarehouseFullView warehouseView)
        {
            try
            {
                Warehouse warehouseEntity = _mapper.Map<WarehouseFullView, Warehouse>(warehouseView);
                _unitOfWork.WarehouseRepository.Update(warehouseEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WarehouseLogic.Update");
                throw;
            }
        }
    }
}
