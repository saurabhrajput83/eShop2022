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
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<VariationLogic> _logger;


        public VariationLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<VariationLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid variationGuid)
        {
            try
            {
                Variation variationEntity = await _unitOfWork.VariationRepository.GetByGuidAsync(variationGuid, _token);
                if (variationEntity.IsNotNull())
                {
                    _unitOfWork.VariationRepository.Delete(variationEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.Delete");
                throw;
            }
        }

        public async Task<List<VariationMinimalView>> GetAllAsync()
        {
            try
            {
                List<Variation> result = await _unitOfWork.VariationRepository.GetAllAsync(_token);
                return _mapper.Map<List<VariationMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.GetAll");
                throw;
            }
        }

        public async Task<VariationFullView> GetByGuidAsync(Guid variationGuid)
        {
            try
            {
                Variation variationEntity = await _unitOfWork.VariationRepository.GetByGuidAsync(variationGuid, _token);
                return _mapper.Map<VariationFullView>(variationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.variationGuid");
                throw;
            }
        }

        public async Task<VariationFullView> InsertAsync(VariationFullView variationView)
        {
            try
            {
                Variation variationEntity = _mapper.Map<Variation>(variationView);
                await _unitOfWork.VariationRepository.InsertAsync(variationEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<VariationFullView>(variationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(VariationFullView variationView)
        {
            try
            {
                Variation variationEntity = await _unitOfWork.VariationRepository.GetByGuidAsync(variationView.Guid, _token);
                variationEntity = _mapper.Map<VariationFullView, Variation>(variationView, variationEntity);
                _unitOfWork.VariationRepository.Update(variationEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "VariationLogic.Update");
                throw;
            }
        }
    }
}
