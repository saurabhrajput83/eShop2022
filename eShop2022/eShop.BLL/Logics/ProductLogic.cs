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
    public class ProductLogic : IProductLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductLogic> _logger;


        public ProductLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid productGuid)
        {
            try
            {
                Product productEntity = await _unitOfWork.ProductRepository.GetByGuidAsync(productGuid, _token);
                if (productEntity.IsNotNull())
                {
                    _unitOfWork.ProductRepository.Delete(productEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.Delete");
                throw;
            }
        }

        public async Task<List<ProductMinimalView>> GetAllAsync()
        {
            try
            {
                List<Product> result = await _unitOfWork.ProductRepository.GetAllAsync(_token);
                return _mapper.Map<List<ProductMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.GetAll");
                throw;
            }
        }

        public async Task<ProductFullView> GetByGuidAsync(Guid productGuid)
        {
            try
            {
                Product productEntity = await _unitOfWork.ProductRepository.GetByGuidAsync(productGuid, _token);
                return _mapper.Map<ProductFullView>(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.productGuid");
                throw;
            }
        }

        public async Task<ProductFullView> InsertAsync(ProductFullView productView)
        {
            try
            {
                Product productEntity = _mapper.Map<Product>(productView);
                await _unitOfWork.ProductRepository.InsertAsync(productEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<ProductFullView>(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(ProductFullView productView)
        {
            try
            {
                Product productEntity = await _unitOfWork.ProductRepository.GetByGuidAsync(productView.Guid, _token);
                productEntity = _mapper.Map<ProductFullView, Product>(productView, productEntity);
                _unitOfWork.ProductRepository.Update(productEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.Update");
                throw;
            }
        }
    }
}
