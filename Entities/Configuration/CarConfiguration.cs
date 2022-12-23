using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData
            (
            new Car
            {
                Id = 1,
                CarName = "Bexa tt",
                CarCost = 800,
                CarShopId = 1 ,
            },
            new Car
            {
                Id = 2,
                CarName = "hyandya",
                CarCost = 500,
                CarShopId = 2,
            }
            );
        }
    }
}
