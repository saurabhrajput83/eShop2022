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
    public class VariationTypeLogic : IVariationTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<VariationTypeLogic> _logger;


        public VariationTypeLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<VariationTypeLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid variationTypeGuid)
        {
            try
            {
                VariationType variationTypeEntity = _unitOfWork.VariationTypeRepository.GetByGuid(variationTypeGuid);
                if (variationTypeEntity.IsNotNull())
                {
                    variationTypeEntity = _unitOfWork.VariationTypeRepository.Delete(variationTypeEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.Delete");
                throw;
            }
        }

        public List<VariationTypeMinimalView> GetAll()
        {
            try
            {
                List<VariationType> result = _unitOfWork.VariationTypeRepository.GetAll().ToList();
                return _mapper.Map<List<VariationTypeMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.GetAll");
                throw;
            }
        }

        public VariationTypeFullView GetByGuid(Guid variationTypeGuid)
        {
            try
            {
                VariationType variationTypeEntity = _unitOfWork.VariationTypeRepository.GetByGuid(variationTypeGuid);
                return _mapper.Map<VariationTypeFullView>(variationTypeEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.variationTypeGuid");
                throw;
            }
        }

        public VariationTypeFullView Insert(VariationTypeFullView variationTypeView)
        {
            try
            {
                VariationType variationTypeEntity = _mapper.Map<VariationType>(variationTypeView);
                variationTypeEntity = _unitOfWork.VariationTypeRepository.Insert(variationTypeEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<VariationTypeFullView>(variationTypeEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.Insert");
                throw;
            }
        }

        public void Update(VariationTypeFullView variationTypeView)
        {
            try
            {
                VariationType variationTypeEntity = _mapper.Map<VariationTypeFullView, VariationType>(variationTypeView);
                _unitOfWork.VariationTypeRepository.Update(variationTypeEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.Update");
                throw;
            }
        }
    }
}
