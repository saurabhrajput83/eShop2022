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
    public class ShoppingCartLogic : IShoppingCartLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ShoppingCartLogic> _logger;


        public ShoppingCartLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<ShoppingCartLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid shoppingCartGuid)
        {
            try
            {
                ShoppingCart shoppingCartEntity = _unitOfWork.ShoppingCartRepository.GetByGuid(shoppingCartGuid);
                if (shoppingCartEntity.IsNotNull())
                {
                    _unitOfWork.ShoppingCartRepository.Delete(shoppingCartEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.Delete");
                throw;
            }
        }

        public List<ShoppingCartView> GetAll()
        {
            try
            {
                List<ShoppingCart> result = _unitOfWork.ShoppingCartRepository.GetAll().ToList();
                return _mapper.Map<List<ShoppingCartView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.GetAll");
                throw;
            }
        }

        public ShoppingCartView GetByGuid(Guid shoppingCartGuid)
        {
            try
            {
                ShoppingCart shoppingCartEntity = _unitOfWork.ShoppingCartRepository.GetByGuid(shoppingCartGuid);
                return _mapper.Map<ShoppingCartView>(shoppingCartEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.shoppingCartGuid");
                throw;
            }
        }

        public ShoppingCartView Insert(ShoppingCartView shoppingCartView)
        {
            try
            {
                ShoppingCart shoppingCartEntity = _mapper.Map<ShoppingCart>(shoppingCartView);
                _unitOfWork.ShoppingCartRepository.Insert(shoppingCartEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<ShoppingCartView>(shoppingCartEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.Insert");
                throw;
            }
        }

        public void Update(ShoppingCartView shoppingCartView)
        {
            try
            {
                ShoppingCart shoppingCartEntity = _mapper.Map<ShoppingCartView, ShoppingCart>(shoppingCartView);
                _unitOfWork.ShoppingCartRepository.Update(shoppingCartEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.Update");
                throw;
            }
        }
    }
}
