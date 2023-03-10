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
        private readonly VariationTypeLogicHelper _variationTypeLogicHelper;

        public VariationLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _variationTypeLogicHelper = new VariationTypeLogicHelper(_appServices);
        }

        public async Task<VariationFullView> GetTestVariationView(Guid variationGuid)
        {
            VariationTypeFullView variationType = await _variationTypeLogicHelper.InsertAsync(Constants.VariationTypeGuid);

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

        public override async Task<VariationFullView> InsertAsync(Guid variationGuid)
        {
            VariationFullView variationView = await GetTestVariationView(variationGuid);
            return await _appServices.VariationLogic.InsertAsync(variationView);
        }

        public override async Task DeleteAsync(Guid variationGuid)
        {
            await _appServices.VariationLogic.DeleteAsync(variationGuid);
        }

        public override async Task CleanUpAsync()
        {
            await _variationTypeLogicHelper.DeleteAsync(Constants.VariationTypeGuid);
            await _variationTypeLogicHelper.CleanUpAsync();
        }

    }
}
