using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Repositories.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        IEnumerable<Review> GetByProductId(int productId);
    }
}
