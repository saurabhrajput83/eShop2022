using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class BrandHelper : BaseHelper<BrandView>
    {
        private readonly IBrandLogic _brandLogic;
        public BrandHelper(IBrandLogic brandLogic)
        {
            _brandLogic = brandLogic;
        }

        public static BrandView GetTestBrandView(Guid brandGuid)
        {
            BrandView brandView = new BrandView()
            {
                Guid = brandGuid,
                Name = "Test Brand Name",
                Description = "Test Brand Description",
                IsHidden = false
            };

            return brandView;

        }

        public override BrandView Insert(Guid brandGuid)
        {
            BrandView brandView = GetTestBrandView(brandGuid);
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
