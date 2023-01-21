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
    public class ProductImageLogic : IProductImageLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductImageLogic> _logger;


        public ProductImageLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductImageLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid productImageGuid)
        {
            try
            {
                ProductImage productImageEntity = _unitOfWork.ProductImageRepository.GetByGuid(productImageGuid);
                if (productImageEntity.IsNotNull())
                {
                    productImageEntity = _unitOfWork.ProductImageRepository.Delete(productImageEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.Delete");
                throw;
            }
        }

        public List<ProductImageView> GetAll()
        {
            try
            {
                List<ProductImage> result = _unitOfWork.ProductImageRepository.GetAll().ToList();
                return _mapper.Map<List<ProductImageView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.GetAll");
                throw;
            }
        }

        public ProductImageView GetByGuid(Guid productImageGuid)
        {
            try
            {
                ProductImage productImageEntity = _unitOfWork.ProductImageRepository.GetByGuid(productImageGuid);
                return _mapper.Map<ProductImageView>(productImageEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.productImageGuid");
                throw;
            }
        }

        public ProductImageView Insert(ProductImageView productImageView)
        {
            try
            {
                ProductImage productImageEntity = _mapper.Map<ProductImage>(productImageView);
                productImageEntity = _unitOfWork.ProductImageRepository.Insert(productImageEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<ProductImageView>(productImageEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.Insert");
                throw;
            }
        }

        public void Update(ProductImageView productImageView)
        {
            try
            {
                ProductImage productImageEntity = _mapper.Map<ProductImageView, ProductImage>(productImageView);
                _unitOfWork.ProductImageRepository.Update(productImageEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductImageLogic.Update");
                throw;
            }
        }
    }
}
