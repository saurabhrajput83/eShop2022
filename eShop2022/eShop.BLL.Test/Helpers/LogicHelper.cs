using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class LogicHelper : ILogicHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private IBrandLogic _brandLogic;
        private IDepartmentLogic _departmentLogic;
        private IDepartmentProductLogic _departmentProductLogic;
        private IInventoryLogic _inventoryLogic;
        private IProductImageLogic _productImageLogic;
        private IProductLogic _productLogic;
        private IProductVariationLogic _productVariationLogic;
        private IReviewLogic _reviewLogic;
        private ISelectedItemLogic _selectedItemLogic;
        private IShoppingCartLogic _shoppingCartLogic;
        private IVariationLogic _variationLogic;
        private IVariationTypeLogic _variationTypeLogic;
        private IWarehouseLogic _warehouseLogic;

        private readonly ILogger<BrandLogic> _brandLogicLogger;
        private readonly ILogger<DepartmentLogic> _departmentLogicLogger;
        private readonly ILogger<DepartmentProductLogic> _departmentProductLogicLogger;
        private readonly ILogger<InventoryLogic> _inventoryLogicLogger;
        private readonly ILogger<ProductImageLogic> _productImageLogicLogger;
        private readonly ILogger<ProductLogic> _productLogicLogger;
        private readonly ILogger<ProductVariationLogic> _productVariationLogicLogger;
        private readonly ILogger<ReviewLogic> _reviewLogicLogger;
        private readonly ILogger<SelectedItemLogic> _selectedItemLogicLogger;
        private readonly ILogger<ShoppingCartLogic> _shoppingCartLogicLogger;
        private readonly ILogger<VariationLogic> _variationLogicLogger;
        private readonly ILogger<VariationTypeLogic> _variationTypeLogicLogger;
        private readonly ILogger<WarehouseLogic> _warehouseLogicLogger;

        public LogicHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = AutoMapperConfiguration.Configure();

            _brandLogicLogger = LoggerConfiguration.Configuration<BrandLogic>();
            _departmentLogicLogger = LoggerConfiguration.Configuration<DepartmentLogic>();
            _departmentProductLogicLogger = LoggerConfiguration.Configuration<DepartmentProductLogic>();
            _inventoryLogicLogger = LoggerConfiguration.Configuration<InventoryLogic>();
            _productImageLogicLogger = LoggerConfiguration.Configuration<ProductImageLogic>();
            _productLogicLogger = LoggerConfiguration.Configuration<ProductLogic>();
            _productVariationLogicLogger = LoggerConfiguration.Configuration<ProductVariationLogic>();
            _reviewLogicLogger = LoggerConfiguration.Configuration<ReviewLogic>();
            _selectedItemLogicLogger = LoggerConfiguration.Configuration<SelectedItemLogic>();
            _shoppingCartLogicLogger = LoggerConfiguration.Configuration<ShoppingCartLogic>();
            _variationLogicLogger = LoggerConfiguration.Configuration<VariationLogic>();
            _variationTypeLogicLogger = LoggerConfiguration.Configuration<VariationTypeLogic>();
            _warehouseLogicLogger = LoggerConfiguration.Configuration<WarehouseLogic>();
        }

        public IBrandLogic BrandLogic
        {
            get
            {
                return _brandLogic = _brandLogic ?? new BrandLogic(_unitOfWork, _mapper, _brandLogicLogger);
            }
        }
        public IDepartmentLogic DepartmentLogic
        {
            get
            {
                return _departmentLogic = _departmentLogic ?? new DepartmentLogic(_unitOfWork, _mapper, _departmentLogicLogger);
            }
        }
        public IDepartmentProductLogic DepartmentProductLogic
        {
            get
            {
                return _departmentProductLogic = _departmentProductLogic ?? new DepartmentProductLogic(_unitOfWork, _mapper, _departmentProductLogicLogger);
            }
        }
        public IInventoryLogic InventoryLogic
        {
            get
            {
                return _inventoryLogic = _inventoryLogic ?? new InventoryLogic(_unitOfWork, _mapper, _inventoryLogicLogger);
            }
        }
        public IProductLogic ProductLogic
        {
            get
            {
                return _productLogic = _productLogic ?? new ProductLogic(_unitOfWork, _mapper, _productLogicLogger);
            }
        }
        public IProductImageLogic ProductImageLogic
        {
            get
            {
                return _productImageLogic = _productImageLogic ?? new ProductImageLogic(_unitOfWork, _mapper, _productImageLogicLogger);
            }
        }
        public IProductVariationLogic ProductVariationLogic
        {
            get
            {
                return _productVariationLogic = _productVariationLogic
                    ?? new ProductVariationLogic(_unitOfWork, _mapper, _productVariationLogicLogger);
            }
        }
        public IReviewLogic ReviewLogic
        {
            get
            {
                return _reviewLogic = _reviewLogic ?? new ReviewLogic(_unitOfWork, _mapper, _reviewLogicLogger);
            }
        }
        public ISelectedItemLogic SelectedItemLogic
        {
            get
            {
                return _selectedItemLogic = _selectedItemLogic ?? new SelectedItemLogic(_unitOfWork, _mapper, _selectedItemLogicLogger);
            }
        }
        public IShoppingCartLogic ShoppingCartLogic
        {
            get
            {
                return _shoppingCartLogic = _shoppingCartLogic ?? new ShoppingCartLogic(_unitOfWork, _mapper, _shoppingCartLogicLogger);
            }
        }
        public IVariationTypeLogic VariationTypeLogic
        {
            get
            {
                return _variationTypeLogic = _variationTypeLogic ?? new VariationTypeLogic(_unitOfWork, _mapper, _variationTypeLogicLogger);
            }
        }
        public IVariationLogic VariationLogic
        {
            get
            {
                return _variationLogic = _variationLogic ?? new VariationLogic(_unitOfWork, _mapper, _variationLogicLogger);
            }
        }
        public IWarehouseLogic WarehouseLogic
        {
            get
            {
                return _warehouseLogic = _warehouseLogic ?? new WarehouseLogic(_unitOfWork, _mapper, _warehouseLogicLogger);
            }
        }

    }
}
