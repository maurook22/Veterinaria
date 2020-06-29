using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pericles.Models
{
    public class Mascota
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Raza { get; set; }

        [Range(0, 100)]
        public int Edad { get; set; }

        
        [EnumDataType(typeof(TipoAnimal))]
        [Display(Name = "Animal")]
        public TipoAnimal TipoAnimal { get; set; }

        [Display(Name = "Dueño")]
        public int DuenioID { get; set; }

        [Display(Name = "Dueño")]
        public Duenio Duenio { get; set; }

    }
}
