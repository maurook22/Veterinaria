using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pericles.Models
{
    public class Veterinario
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [MaxLength(10)]
        public string Matricula { get; set; }

        [Required]
        public int Telefono { get; set; }
    }
}
