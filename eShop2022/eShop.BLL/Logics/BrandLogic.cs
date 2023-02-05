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
    public class BrandLogic : IBrandLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandLogic> _logger;


        public BrandLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid brandGuid)
        {
            try
            {
                Brand brandEntity = _unitOfWork.BrandRepository.GetByGuid(brandGuid);
                if (brandEntity.IsNotNull())
                {
                    _unitOfWork.BrandRepository.Delete(brandEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.Delete");
                throw;
            }
        }

        public List<BrandMinimalView> GetAll()
        {
            try
            {
                List<Brand> result = _unitOfWork.BrandRepository.GetAll().ToList();
                return _mapper.Map<List<BrandMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.GetAll");
                throw;
            }
        }

        public BrandFullView GetByGuid(Guid brandGuid)
        {
            try
            {
                Brand brandEntity = _unitOfWork.BrandRepository.GetByGuid(brandGuid);
                return _mapper.Map<BrandFullView>(brandEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.brandGuid");
                throw;
            }
        }

        public BrandFullView Insert(BrandFullView brandView)
        {
            try
            {
                Brand brandEntity = _mapper.Map<Brand>(brandView);
                _unitOfWork.BrandRepository.Insert(brandEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<BrandFullView>(brandEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.Insert");
                throw;
            }
        }

        public void Update(BrandFullView brandView)
        {
            try
            {
                Brand brandEntity = _unitOfWork.BrandRepository.GetByGuid(brandView.Guid);
                brandEntity = _mapper.Map<BrandFullView, Brand>(brandView, brandEntity);
                _unitOfWork.BrandRepository.Update(brandEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.Update");
                throw;
            }
        }
    }
}
