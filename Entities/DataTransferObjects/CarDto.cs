using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CarDto
    {
        public int Id { get; set; }
     
        public string CarName { get; set; }
       
        public int CarCost { get; set; }


    }
}
