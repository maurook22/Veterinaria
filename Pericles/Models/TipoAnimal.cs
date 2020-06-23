using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pericles.Models
{
    public enum TipoAnimal
    {

        [Display(Name = "Perro")]
        Perro = 1,

        [Display(Name = "Gato")]
        Gato = 2,

        [Display(Name = "Loro")]
        Loro = 3,

        [Display(Name = "Hamster")]
        Hamster = 4,

        [Display(Name = "Coballo")]
        Coballo = 5,

        [Display(Name = "Conejo")]
        Conejo = 6

    }

}
