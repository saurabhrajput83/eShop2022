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
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandLogic> _logger;


        public BrandLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid brandGuid)
        {
            try
            {
                Brand brandEntity = await _unitOfWork.BrandRepository.GetByGuidAsync(brandGuid, _token);
                if (brandEntity.IsNotNull())
                {
                    _unitOfWork.BrandRepository.Delete(brandEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.Delete");
                throw;
            }
        }

        public async Task<List<BrandMinimalView>> GetAllAsync()
        {
            try
            {
                List<Brand> result = await _unitOfWork.BrandRepository.GetAllAsync(_token);
                return _mapper.Map<List<BrandMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.GetAll");
                throw;
            }
        }

        public async Task<BrandFullView> GetByGuidAsync(Guid brandGuid)
        {
            try
            {
                Brand brandEntity = await _unitOfWork.BrandRepository.GetByGuidAsync(brandGuid, _token);
                return _mapper.Map<BrandFullView>(brandEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.brandGuid");
                throw;
            }
        }

        public async Task<BrandFullView> InsertAsync(BrandFullView brandView)
        {
            try
            {
                Brand brandEntity = _mapper.Map<Brand>(brandView);
                await _unitOfWork.BrandRepository.InsertAsync(brandEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<BrandFullView>(brandEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(BrandFullView brandView)
        {
            try
            {
                Brand brandEntity = await _unitOfWork.BrandRepository.GetByGuidAsync(brandView.Guid, _token);
                brandEntity = _mapper.Map<BrandFullView, Brand>(brandView, brandEntity);
                _unitOfWork.BrandRepository.Update(brandEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BrandLogic.Update");
                throw;
            }
        }
    }
}
