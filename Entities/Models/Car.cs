using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Car
    {
        [Column("CarId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "CarName is a required field.")]
        [MaxLength(60, ErrorMessage = "CarName length for the Name is 60 characters.")]
        public string CarName { get; set; }
        [Required(ErrorMessage = "Car Cost is a required field.")]
        public int CarCost { get; set; }

        [ForeignKey(nameof(CarShop))]
        public int CarShopId { get; set; }
        public CarShop CarShop { get; set; }
    }
}
