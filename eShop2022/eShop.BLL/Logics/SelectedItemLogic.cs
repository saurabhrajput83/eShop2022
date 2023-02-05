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
        private readonly IMapper _mapper;
        private readonly ILogger<SelectedItemLogic> _logger;


        public SelectedItemLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<SelectedItemLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid selectedItemGuid)
        {
            try
            {
                SelectedItem selectedItemEntity = _unitOfWork.SelectedItemRepository.GetByGuid(selectedItemGuid);
                if (selectedItemEntity.IsNotNull())
                {
                    _unitOfWork.SelectedItemRepository.Delete(selectedItemEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.Delete");
                throw;
            }
        }

        public List<SelectedItemMinimalView> GetAll()
        {
            try
            {
                List<SelectedItem> result = _unitOfWork.SelectedItemRepository.GetAll().ToList();
                return _mapper.Map<List<SelectedItemMinimalView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.GetAll");
                throw;
            }
        }

        public SelectedItemFullView GetByGuid(Guid selectedItemGuid)
        {
            try
            {
                SelectedItem selectedItemEntity = _unitOfWork.SelectedItemRepository.GetByGuid(selectedItemGuid);
                return _mapper.Map<SelectedItemFullView>(selectedItemEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.selectedItemGuid");
                throw;
            }
        }

        public SelectedItemFullView Insert(SelectedItemFullView selectedItemView)
        {
            try
            {
                SelectedItem selectedItemEntity = _mapper.Map<SelectedItem>(selectedItemView);
                _unitOfWork.SelectedItemRepository.Insert(selectedItemEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<SelectedItemFullView>(selectedItemEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.Insert");
                throw;
            }
        }

        public void Update(SelectedItemFullView selectedItemView)
        {
            try
            {
                SelectedItem selectedItemEntity = _mapper.Map<SelectedItemFullView, SelectedItem>(selectedItemView);
                _unitOfWork.SelectedItemRepository.Update(selectedItemEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SelectedItemLogic.Update");
                throw;
            }
        }
    }
}
