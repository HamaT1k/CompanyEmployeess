using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CarShop
    {
        [Column("CarShopId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "CarShopName is a required field.")]
        [MaxLength(60, ErrorMessage = "CarShopName length for the Name is 60 characters.")]
        public string CarShopName { get; set; }

        [Required(ErrorMessage = "Addres is a required field.")]
        public string Address { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
