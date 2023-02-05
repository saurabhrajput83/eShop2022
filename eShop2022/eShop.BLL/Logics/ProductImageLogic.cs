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
    public class ProductImageLogic : IProductImageLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductImageLogic> _logger;


        public ProductImageLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductImageLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid productImageGuid)
        {
            try
            {
                ProductImage productImageEntity = await _unitOfWork.ProductImageRepository.GetByGuidAsync(productImageGuid, _token);
                if (productImageEntity.IsNotNull())
                {
                    _unitOfWork.ProductImageRepository.Delete(productImageEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.Delete");
                throw;
            }
        }

        public async Task<List<ProductImageView>> GetAllAsync()
        {
            try
            {
                List<ProductImage> result = await _unitOfWork.ProductImageRepository.GetAllAsync(_token);
                return _mapper.Map<List<ProductImageView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.GetAll");
                throw;
            }
        }

        public async Task<ProductImageView> GetByGuidAsync(Guid productImageGuid)
        {
            try
            {
                ProductImage productImageEntity = await _unitOfWork.ProductImageRepository.GetByGuidAsync(productImageGuid, _token);
                return _mapper.Map<ProductImageView>(productImageEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.productImageGuid");
                throw;
            }
        }

        public async Task<ProductImageView> InsertAsync(ProductImageView productImageView)
        {
            try
            {
                ProductImage productImageEntity = _mapper.Map<ProductImage>(productImageView);
                await _unitOfWork.ProductImageRepository.InsertAsync(productImageEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<ProductImageView>(productImageEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(ProductImageView productImageView)
        {
            try
            {
                ProductImage productImageEntity = _mapper.Map<ProductImageView, ProductImage>(productImageView);
                _unitOfWork.ProductImageRepository.Update(productImageEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.Update");
                throw;
            }
        }
    }
}
