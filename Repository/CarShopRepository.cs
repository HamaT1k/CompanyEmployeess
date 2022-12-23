using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarShopRepository : RepositoryBase<CarShop>, ICarShopRepository
    {
        public CarShopRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }


        public IEnumerable<CarShop> GetAllCarShops(bool trackChanges) =>
     FindAll(trackChanges)
         .OrderBy(c => c.CarShopName)
         .ToList();
    }
}
