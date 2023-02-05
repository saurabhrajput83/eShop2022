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
    public class VariationLogic : IVariationLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<VariationLogic> _logger;


        public VariationLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<VariationLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid variationGuid)
        {
            try
            {
                Variation variationEntity = _unitOfWork.VariationRepository.GetByGuid(variationGuid);
                if (variationEntity.IsNotNull())
                {
                    _unitOfWork.VariationRepository.Delete(variationEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.Delete");
                throw;
            }
        }

        public List<VariationMinimalView> GetAll()
        {
            try
            {
                List<Variation> result = _unitOfWork.VariationRepository.GetAll().ToList();
                return _mapper.Map<List<VariationMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.GetAll");
                throw;
            }
        }

        public VariationFullView GetByGuid(Guid variationGuid)
        {
            try
            {
                Variation variationEntity = _unitOfWork.VariationRepository.GetByGuid(variationGuid);
                return _mapper.Map<VariationFullView>(variationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.variationGuid");
                throw;
            }
        }

        public VariationFullView Insert(VariationFullView variationView)
        {
            try
            {
                Variation variationEntity = _mapper.Map<Variation>(variationView);
                _unitOfWork.VariationRepository.Insert(variationEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<VariationFullView>(variationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.Insert");
                throw;
            }
        }

        public void Update(VariationFullView variationView)
        {
            try
            {
                Variation variationEntity = _mapper.Map<VariationFullView, Variation>(variationView);
                _unitOfWork.VariationRepository.Update(variationEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.Update");
                throw;
            }
        }
    }
}
