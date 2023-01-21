using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
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
    public class BrandLogicHelper : BaseHelper<BrandFullView>
    {
        private readonly ILogicHelper _logicHelper;

        public BrandLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
        }

        public BrandFullView GetTestBrandView(Guid brandGuid)
        {
            BrandFullView brandView = new BrandFullView()
            {
                Guid = brandGuid,
                Name = "Test Brand Name",
                Description = "Test Brand Description",
                IsHidden = false,
            };

            UpdateView(brandView);

            return brandView;

        }

        public override BrandFullView Insert(Guid brandGuid)
        {
            BrandFullView brandView = GetTestBrandView(brandGuid);
            return _logicHelper.BrandLogic.Insert(brandView);
        }

        public override void Delete(Guid brandGuid)
        {
            _logicHelper.BrandLogic.Delete(brandGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
