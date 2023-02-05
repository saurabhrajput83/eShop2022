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
    public class VariationTypeLogic : IVariationTypeLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<VariationTypeLogic> _logger;


        public VariationTypeLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<VariationTypeLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid variationTypeGuid)
        {
            try
            {
                VariationType variationTypeEntity = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(variationTypeGuid, _token);
                if (variationTypeEntity.IsNotNull())
                {
                    _unitOfWork.VariationTypeRepository.Delete(variationTypeEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.Delete");
                throw;
            }
        }

        public async Task<List<VariationTypeMinimalView>> GetAllAsync()
        {
            try
            {
                List<VariationType> result = await _unitOfWork.VariationTypeRepository.GetAllAsync(_token);
                return _mapper.Map<List<VariationTypeMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.GetAll");
                throw;
            }
        }

        public async Task<VariationTypeFullView> GetByGuidAsync(Guid variationTypeGuid)
        {
            try
            {
                VariationType variationTypeEntity = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(variationTypeGuid, _token);
                return _mapper.Map<VariationTypeFullView>(variationTypeEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.variationTypeGuid");
                throw;
            }
        }

        public async Task<VariationTypeFullView> InsertAsync(VariationTypeFullView variationTypeView)
        {
            try
            {
                VariationType variationTypeEntity = _mapper.Map<VariationType>(variationTypeView);
                await _unitOfWork.VariationTypeRepository.InsertAsync(variationTypeEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<VariationTypeFullView>(variationTypeEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(VariationTypeFullView variationTypeView)
        {
            try
            {
                VariationType variationTypeEntity = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(variationTypeView.Guid, _token);
                variationTypeEntity = _mapper.Map<VariationTypeFullView, VariationType>(variationTypeView, variationTypeEntity);
                _unitOfWork.VariationTypeRepository.Update(variationTypeEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationTypeLogic.Update");
                throw;
            }
        }
    }
}
