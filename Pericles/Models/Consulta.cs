using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pericles.Models
{
    public class Consulta
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Fecha de consulta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico { get; set; }

        [Required]
        [Display(Name = "Mascota")]
        public int MascotaID { get; set; }

        [Required]
        [Display(Name = "Veterinario")]
        public int VeterinarioID { get; set; }

        public Mascota Mascota { get; set; }
        public Veterinario Veterinario{ get; set; }
    }
}
