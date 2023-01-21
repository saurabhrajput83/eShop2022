using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class BrandHelper : BaseHelper<BrandFullView>
    {
        private readonly IBrandLogic _brandLogic;
        public BrandHelper(IBrandLogic brandLogic)
        {
            _brandLogic = brandLogic;
        }

        public static BrandFullView GetTestBrandView(Guid brandGuid)
        {
            BrandFullView brandView = new BrandFullView()
            {
                Guid = brandGuid,
                Name = "Test Brand Name",
                Description = "Test Brand Description",
                IsHidden = false,
            };

            return brandView;

        }

        public override BrandFullView Insert(Guid brandGuid)
        {
            BrandFullView brandView = GetTestBrandView(brandGuid);
            return _brandLogic.Insert(brandView);
        }

        public override void Delete(Guid brandGuid)
        {
            _brandLogic.Delete(brandGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
