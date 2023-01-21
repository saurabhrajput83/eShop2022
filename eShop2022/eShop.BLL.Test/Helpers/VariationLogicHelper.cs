using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Entities;
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
    public class VariationLogicHelper : BaseHelper<VariationFullView>
    {
        private readonly ILogicHelper _logicHelper;
        private readonly VariationTypeLogicHelper _variationTypeLogicHelper;

        public VariationLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
            _variationTypeLogicHelper = new VariationTypeLogicHelper(_logicHelper);
        }

        public VariationFullView GetTestVariationView(Guid variationGuid)
        {
            VariationTypeFullView variationType = _variationTypeLogicHelper.Insert(Constants.VariationTypeGuid);

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
            return _logicHelper.VariationLogic.Insert(variationView);
        }

        public override void Delete(Guid variationGuid)
        {
            _logicHelper.VariationLogic.Delete(variationGuid);
        }

        public override void CleanUp()
        {
            _variationTypeLogicHelper.Delete(Constants.VariationTypeGuid);
            _variationTypeLogicHelper.CleanUp();
        }

    }
}
