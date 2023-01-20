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
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandLogic()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _mapper = AutoMapperConfiguration.Configure();
        }

        public void Delete(Guid brandGuid)
        {
            try
            {
                Brand brandEntity = _unitOfWork.BrandRepository.GetByGuid(brandGuid);
                if (brandEntity.IsNotNull())
                {
                    brandEntity = _unitOfWork.BrandRepository.Delete(brandEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BrandView> GetAll()
        {
            try
            {
                List<Brand> result = _unitOfWork.BrandRepository.GetAll().ToList();
                return _mapper.Map<List<BrandView>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BrandView GetByGuid(Guid brandGuid)
        {
            try
            {
                Brand brandEntity = _unitOfWork.BrandRepository.GetByGuid(brandGuid);
                return _mapper.Map<BrandView>(brandEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BrandView Insert(BrandView brandView)
        {
            try
            {
                Brand brandEntity = _mapper.Map<Brand>(brandView);
                brandEntity = _unitOfWork.BrandRepository.Insert(brandEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<BrandView>(brandEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(BrandView brandView)
        {
            try
            {
                Brand brandEntity = _mapper.Map<BrandView, Brand>(brandView);
                _unitOfWork.BrandRepository.Update(brandEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
