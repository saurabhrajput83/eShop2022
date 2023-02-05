using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.DAL.Implementations;
using eShop.DAL.Main;
using eShop.DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eShop.BLL.Services
{
    public class AppServices : IAppServices
    {
        private readonly IAppUnitOfWork _unitOfWork;
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


        public AppServices(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = AutoMapperConfiguration.Configure();

        }

        public IBrandLogic BrandLogic
        {
            get
            {
                if (_brandLogic == null)
                {
                    ILogger<BrandLogic> logger = LoggerConfiguration.Configuration<BrandLogic>();
                    _brandLogic = new BrandLogic(_unitOfWork, _mapper, logger);
                }
                return _brandLogic;
            }
        }
        public IDepartmentLogic DepartmentLogic
        {
            get
            {
                if (_departmentLogic == null)
                {
                    ILogger<DepartmentLogic> logger = LoggerConfiguration.Configuration<DepartmentLogic>();
                    _departmentLogic = new DepartmentLogic(_unitOfWork, _mapper, logger);
                }
                return _departmentLogic;
            }
        }
        public IDepartmentProductLogic DepartmentProductLogic
        {
            get
            {
                if (_departmentProductLogic == null)
                {
                    ILogger<DepartmentProductLogic> logger = LoggerConfiguration.Configuration<DepartmentProductLogic>();
                    _departmentProductLogic = new DepartmentProductLogic(_unitOfWork, _mapper, logger);
                }
                return _departmentProductLogic;
            }
        }
        public IInventoryLogic InventoryLogic
        {
            get
            {
                if (_inventoryLogic == null)
                {

                    ILogger<InventoryLogic> logger = LoggerConfiguration.Configuration<InventoryLogic>();
                    _inventoryLogic = new InventoryLogic(_unitOfWork, _mapper, logger);
                }
                return _inventoryLogic;
            }
        }
        public IProductLogic ProductLogic
        {
            get
            {
                if (_productLogic == null)
                {
                    ILogger<ProductLogic> logger = LoggerConfiguration.Configuration<ProductLogic>();
                    _productLogic = new ProductLogic(_unitOfWork, _mapper, logger);
                }
                return _productLogic;
            }
        }
        public IProductImageLogic ProductImageLogic
        {
            get
            {
                if (_productImageLogic == null)
                {
                    ILogger<ProductImageLogic> logger = LoggerConfiguration.Configuration<ProductImageLogic>();
                    _productImageLogic = new ProductImageLogic(_unitOfWork, _mapper, logger);
                }
                return _productImageLogic;
            }
        }
        public IProductVariationLogic ProductVariationLogic
        {
            get
            {
                if (_productVariationLogic == null)
                {
                    ILogger<ProductVariationLogic> logger = LoggerConfiguration.Configuration<ProductVariationLogic>();
                    _productVariationLogic = new ProductVariationLogic(_unitOfWork, _mapper, logger);
                }
                return _productVariationLogic;
            }
        }
        public IReviewLogic ReviewLogic
        {
            get
            {
                if (_reviewLogic == null)
                {
                    ILogger<ReviewLogic> logger = LoggerConfiguration.Configuration<ReviewLogic>();
                    _reviewLogic = new ReviewLogic(_unitOfWork, _mapper, logger);
                }
                return _reviewLogic;
            }
        }
        public ISelectedItemLogic SelectedItemLogic
        {
            get
            {
                if (_selectedItemLogic == null)
                {
                    ILogger<SelectedItemLogic> logger = LoggerConfiguration.Configuration<SelectedItemLogic>();
                    _selectedItemLogic = new SelectedItemLogic(_unitOfWork, _mapper, logger);
                }
                return _selectedItemLogic;
            }
        }
        public IShoppingCartLogic ShoppingCartLogic
        {
            get
            {
                if (_shoppingCartLogic == null)
                {
                    ILogger<ShoppingCartLogic> logger = LoggerConfiguration.Configuration<ShoppingCartLogic>();
                    _shoppingCartLogic = new ShoppingCartLogic(_unitOfWork, _mapper, logger);
                }
                return _shoppingCartLogic;
            }
        }
        public IVariationTypeLogic VariationTypeLogic
        {
            get
            {
                if (_variationTypeLogic == null)
                {
                    ILogger<VariationTypeLogic> logger = LoggerConfiguration.Configuration<VariationTypeLogic>();
                    _variationTypeLogic = new VariationTypeLogic(_unitOfWork, _mapper, logger);
                }
                return _variationTypeLogic;
            }
        }
        public IVariationLogic VariationLogic
        {
            get
            {
                if (_variationLogic == null)
                {
                    ILogger<VariationLogic> logger = LoggerConfiguration.Configuration<VariationLogic>();
                    _variationLogic = new VariationLogic(_unitOfWork, _mapper, logger);
                }
                return _variationLogic;
            }
        }
        public IWarehouseLogic WarehouseLogic
        {
            get
            {
                if (_warehouseLogic == null)
                {
                    ILogger<WarehouseLogic> logger = LoggerConfiguration.Configuration<WarehouseLogic>();
                    _warehouseLogic = new WarehouseLogic(_unitOfWork, _mapper, logger);
                }
                return _warehouseLogic;
            }
        }

    }
}
