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
    public class ProductVariationLogic : IProductVariationLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductVariationLogic> _logger;


        public ProductVariationLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductVariationLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid productVariationGuid)
        {
            try
            {
                ProductVariation productVariationEntity = _unitOfWork.ProductVariationRepository.GetByGuid(productVariationGuid);
                if (productVariationEntity.IsNotNull())
                {
                    productVariationEntity = _unitOfWork.ProductVariationRepository.Delete(productVariationEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.Delete");
                throw;
            }
        }

        public List<ProductVariationMinimalView> GetAll()
        {
            try
            {
                List<ProductVariation> result = _unitOfWork.ProductVariationRepository.GetAll().ToList();
                return _mapper.Map<List<ProductVariationMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.GetAll");
                throw;
            }
        }

        public ProductVariationFullView GetByGuid(Guid productVariationGuid)
        {
            try
            {
                ProductVariation productVariationEntity = _unitOfWork.ProductVariationRepository.GetByGuid(productVariationGuid);
                return _mapper.Map<ProductVariationFullView>(productVariationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.productVariationGuid");
                throw;
            }
        }

        public ProductVariationFullView Insert(ProductVariationFullView productVariationView)
        {
            try
            {
                ProductVariation productVariationEntity = _mapper.Map<ProductVariation>(productVariationView);
                productVariationEntity = _unitOfWork.ProductVariationRepository.Insert(productVariationEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<ProductVariationFullView>(productVariationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.Insert");
                throw;
            }
        }

        public void Update(ProductVariationFullView productVariationView)
        {
            try
            {
                ProductVariation productVariationEntity = _mapper.Map<ProductVariationFullView, ProductVariation>(productVariationView);
                _unitOfWork.ProductVariationRepository.Update(productVariationEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductVariationLogic.Update");
                throw;
            }
        }
    }
}
