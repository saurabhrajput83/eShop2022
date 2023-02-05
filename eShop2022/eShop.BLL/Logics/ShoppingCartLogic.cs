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
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<ShoppingCartLogic> _logger;


        public ShoppingCartLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<ShoppingCartLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid shoppingCartGuid)
        {
            try
            {
                ShoppingCart shoppingCartEntity = await _unitOfWork.ShoppingCartRepository.GetByGuidAsync(shoppingCartGuid, _token);
                if (shoppingCartEntity.IsNotNull())
                {
                    _unitOfWork.ShoppingCartRepository.Delete(shoppingCartEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.Delete");
                throw;
            }
        }

        public async Task<List<ShoppingCartView>> GetAllAsync()
        {
            try
            {
                List<ShoppingCart> result = await _unitOfWork.ShoppingCartRepository.GetAllAsync(_token);
                return _mapper.Map<List<ShoppingCartView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.GetAll");
                throw;
            }
        }

        public async Task<ShoppingCartView> GetByGuidAsync(Guid shoppingCartGuid)
        {
            try
            {
                ShoppingCart shoppingCartEntity = await _unitOfWork.ShoppingCartRepository.GetByGuidAsync(shoppingCartGuid, _token);
                return _mapper.Map<ShoppingCartView>(shoppingCartEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.shoppingCartGuid");
                throw;
            }
        }

        public async Task<ShoppingCartView> InsertAsync(ShoppingCartView shoppingCartView)
        {
            try
            {
                ShoppingCart shoppingCartEntity = _mapper.Map<ShoppingCart>(shoppingCartView);
                await _unitOfWork.ShoppingCartRepository.InsertAsync(shoppingCartEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<ShoppingCartView>(shoppingCartEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(ShoppingCartView shoppingCartView)
        {
            try
            {
                ShoppingCart shoppingCartEntity = _mapper.Map<ShoppingCartView, ShoppingCart>(shoppingCartView);
                _unitOfWork.ShoppingCartRepository.Update(shoppingCartEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShoppingCartLogic.Update");
                throw;
            }
        }
    }
}
