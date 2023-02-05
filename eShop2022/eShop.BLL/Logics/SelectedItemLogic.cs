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
    public class SelectedItemLogic : ISelectedItemLogic
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<SelectedItemLogic> _logger;


        public SelectedItemLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<SelectedItemLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid selectedItemGuid)
        {
            try
            {
                SelectedItem selectedItemEntity = await _unitOfWork.SelectedItemRepository.GetByGuidAsync(selectedItemGuid, _token);
                if (selectedItemEntity.IsNotNull())
                {
                    _unitOfWork.SelectedItemRepository.Delete(selectedItemEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.Delete");
                throw;
            }
        }

        public async Task<List<SelectedItemMinimalView>> GetAllAsync()
        {
            try
            {
                List<SelectedItem> result = await _unitOfWork.SelectedItemRepository.GetAllAsync(_token);
                return _mapper.Map<List<SelectedItemMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.GetAll");
                throw;
            }
        }

        public async Task<SelectedItemFullView> GetByGuidAsync(Guid selectedItemGuid)
        {
            try
            {
                SelectedItem selectedItemEntity = await _unitOfWork.SelectedItemRepository.GetByGuidAsync(selectedItemGuid, _token);
                return _mapper.Map<SelectedItemFullView>(selectedItemEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.selectedItemGuid");
                throw;
            }
        }

        public async Task<SelectedItemFullView> InsertAsync(SelectedItemFullView selectedItemView)
        {
            try
            {
                SelectedItem selectedItemEntity = _mapper.Map<SelectedItem>(selectedItemView);
                await _unitOfWork.SelectedItemRepository.InsertAsync(selectedItemEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<SelectedItemFullView>(selectedItemEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(SelectedItemFullView selectedItemView)
        {
            try
            {
                SelectedItem selectedItemEntity = _mapper.Map<SelectedItemFullView, SelectedItem>(selectedItemView);
                _unitOfWork.SelectedItemRepository.Update(selectedItemEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.Update");
                throw;
            }
        }
    }
}
