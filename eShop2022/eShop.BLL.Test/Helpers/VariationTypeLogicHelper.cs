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
    public class VariationTypeLogicHelper : BaseHelper<VariationTypeFullView>
    {
        private readonly ILogicHelper _logicHelper;

        public VariationTypeLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
        }

        public VariationTypeFullView GetTestVariationTypeView(Guid variationTypeGuid)
        {
            VariationTypeFullView variationTypeView = new VariationTypeFullView()
            {
                Guid = variationTypeGuid,
                Name = "Test VariationType Name",
                Description = "Test VariationType Description"
            };

            UpdateView(variationTypeView);

            return variationTypeView;

        }

        public override VariationTypeFullView Insert(Guid variationTypeGuid)
        {
            VariationTypeFullView variationTypeView = GetTestVariationTypeView(variationTypeGuid);
            return _logicHelper.VariationTypeLogic.Insert(variationTypeView);
        }

        public override void Delete(Guid variationTypeGuid)
        {
            _logicHelper.VariationTypeLogic.Delete(variationTypeGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
