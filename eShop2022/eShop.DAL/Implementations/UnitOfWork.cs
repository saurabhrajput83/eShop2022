﻿using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly eShopDbContext _dbContext;
        private IBrandRepository _brandRepository;
        private IDepartmentProductRepository _departmentProductRepository;
        private IDepartmentRepository _departmentRepository;
        private IInventoryRepository _inventoryRepository;
        private IProductRepository _productRepository;
        private IProductImageRepository _productImageRepository;
        private IProductVariationRepository _productVariationRepository;
        private IReviewRepository _reviewRepository;
        private ISelectedItemRepository _selectedItemRepository;
        private ISelectedItemVariationRepository _selectedItemVariationRepository;
        private IShoppingCartRepository _shoppingCartRepository;
        private IVariationTypeRepository _variationTypeRepository;
        private IVariationRepository _variationRepository;
        private IWarehouseRepository _warehouseRepository;

        public UnitOfWork(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                return _brandRepository = _brandRepository ??
                    new BrandRepository(_dbContext);
            }
        }
        public IDepartmentProductRepository DepartmentProductRepository
        {
            get
            {
                return _departmentProductRepository = _departmentProductRepository
                    ?? new DepartmentProductRepository(_dbContext);
            }
        }
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository = _departmentRepository
                    ?? new DepartmentRepository(_dbContext);
            }
        }
        public IInventoryRepository InventoryRepository
        {
            get
            {
                return _inventoryRepository = _inventoryRepository
                    ?? new InventoryRepository(_dbContext);
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository
                    ?? new ProductRepository(_dbContext);
            }
        }
        public IProductImageRepository ProductImageRepository
        {
            get
            {
                return _productImageRepository = _productImageRepository
                    ?? new ProductImageRepository(_dbContext);
            }
        }
        public IProductVariationRepository ProductVariationRepository
        {
            get
            {
                return _productVariationRepository = _productVariationRepository
                    ?? new ProductVariationRepository(_dbContext);
            }
        }
        public IReviewRepository ReviewRepository
        {
            get
            {
                return _reviewRepository = _reviewRepository
                    ?? new ReviewRepository(_dbContext);
            }
        }
        public ISelectedItemRepository SelectedItemRepository
        {
            get
            {
                return _selectedItemRepository = _selectedItemRepository
                    ?? new SelectedItemRepository(_dbContext);
            }
        }
        public ISelectedItemVariationRepository SelectedItemVariationRepository
        {
            get
            {
                return _selectedItemVariationRepository = _selectedItemVariationRepository
                    ?? new SelectedItemVariationRepository(_dbContext);
            }
        }
        public IShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                return _shoppingCartRepository = _shoppingCartRepository
                    ?? new ShoppingCartRepository(_dbContext);
            }
        }
        public IVariationTypeRepository VariationTypeRepository
        {
            get
            {
                return _variationTypeRepository = _variationTypeRepository
                    ?? new VariationTypeRepository(_dbContext);
            }
        }
        public IVariationRepository VariationRepository
        {
            get
            {
                return _variationRepository = _variationRepository
                    ?? new VariationRepository(_dbContext);
            }
        }
        public IWarehouseRepository WarehouseRepository
        {
            get
            {
                return _warehouseRepository = _warehouseRepository
                    ?? new WarehouseRepository(_dbContext);
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }



}