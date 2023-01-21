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
    public class ProductLogic : IProductLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductLogic> _logger;


        public ProductLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid productGuid)
        {
            try
            {
                Product productEntity = _unitOfWork.ProductRepository.GetByGuid(productGuid);
                if (productEntity.IsNotNull())
                {
                    productEntity = _unitOfWork.ProductRepository.Delete(productEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.Delete");
                throw;
            }
        }

        public List<ProductMinimalView> GetAll()
        {
            try
            {
                List<Product> result = _unitOfWork.ProductRepository.GetAll().ToList();
                return _mapper.Map<List<ProductMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.GetAll");
                throw;
            }
        }

        public ProductFullView GetByGuid(Guid productGuid)
        {
            try
            {
                Product productEntity = _unitOfWork.ProductRepository.GetByGuid(productGuid);
                return _mapper.Map<ProductFullView>(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.productGuid");
                throw;
            }
        }

        public ProductFullView Insert(ProductFullView productView)
        {
            try
            {
                Product productEntity = _mapper.Map<Product>(productView);
                productEntity = _unitOfWork.ProductRepository.Insert(productEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<ProductFullView>(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.Insert");
                throw;
            }
        }

        public void Update(ProductFullView productView)
        {
            try
            {
                Product productEntity = _mapper.Map<ProductFullView, Product>(productView);
                _unitOfWork.ProductRepository.Update(productEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductLogic.Update");
                throw;
            }
        }
    }
}
