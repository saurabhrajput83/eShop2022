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
    public class ProductVariationLogic : IProductVariationLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductVariationLogic> _logger;


        public ProductVariationLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductVariationLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid productVariationGuid)
        {
            try
            {
                ProductVariation productVariationEntity = await _unitOfWork.ProductVariationRepository.GetByGuidAsync(productVariationGuid, _token);
                if (productVariationEntity.IsNotNull())
                {
                    _unitOfWork.ProductVariationRepository.Delete(productVariationEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.Delete");
                throw;
            }
        }

        public async Task<List<ProductVariationMinimalView>> GetAllAsync()
        {
            try
            {
                List<ProductVariation> result = await _unitOfWork.ProductVariationRepository.GetAllAsync(_token);
                return _mapper.Map<List<ProductVariationMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.GetAll");
                throw;
            }
        }

        public async Task<ProductVariationFullView> GetByGuidAsync(Guid productVariationGuid)
        {
            try
            {
                ProductVariation productVariationEntity = await _unitOfWork.ProductVariationRepository.GetByGuidAsync(productVariationGuid, _token);
                return _mapper.Map<ProductVariationFullView>(productVariationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.productVariationGuid");
                throw;
            }
        }

        public async Task<ProductVariationFullView> InsertAsync(ProductVariationFullView productVariationView)
        {
            try
            {
                ProductVariation productVariationEntity = _mapper.Map<ProductVariation>(productVariationView);
                await _unitOfWork.ProductVariationRepository.InsertAsync(productVariationEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<ProductVariationFullView>(productVariationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(ProductVariationFullView productVariationView)
        {
            try
            {
                ProductVariation productVariationEntity = _mapper.Map<ProductVariationFullView, ProductVariation>(productVariationView);
                _unitOfWork.ProductVariationRepository.Update(productVariationEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.Update");
                throw;
            }
        }
    }
}
