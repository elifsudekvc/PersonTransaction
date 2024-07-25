using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DtoLayer.PersonDto
{
    public class CreatePersonDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik 11 Haneli Olmalı.")]
        public string TCKimlik { get; set; }
    }
}
