using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Services;

namespace eShop.BLL.Test.Helpers
{
    public class VariationLogicHelper : BaseHelper<VariationFullView>
    {
        private readonly IAppServices _appServices;
        private readonly VariationTypeLogicHelper _VariationTypeLogicHelper;

        public VariationLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _VariationTypeLogicHelper = new VariationTypeLogicHelper(_appServices);
        }

        public VariationFullView GetTestVariationView(Guid variationGuid)
        {
            VariationTypeFullView variationType = _VariationTypeLogicHelper.Insert(Constants.VariationTypeGuid);

            VariationFullView variationView = new VariationFullView()
            {
                Guid = variationGuid,
                Name = "Test Variation Name",
                Description = "Test Variation Description",
                IsHidden = false,
                VariationTypeId = variationType.Id,
            };

            UpdateView(variationView);

            return variationView;

        }

        public override VariationFullView Insert(Guid variationGuid)
        {
            VariationFullView variationView = GetTestVariationView(variationGuid);
            return _appServices.VariationLogic.Insert(variationView);
        }

        public override void Delete(Guid variationGuid)
        {
            _appServices.VariationLogic.Delete(variationGuid);
        }

        public override void CleanUp()
        {
            _VariationTypeLogicHelper.Delete(Constants.VariationTypeGuid);
            _VariationTypeLogicHelper.CleanUp();
        }

    }
}
