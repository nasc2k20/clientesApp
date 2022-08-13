using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace clientesApp.Models.viewModels
{
    public class clientesViewModel
    {
        public int codCliente { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Digite el Nombre del Cliente")]
        public string nombreCliente { get; set; }
        
        [Required]
        [Display(Name = "Digite el Telefono del Cliente")]
        public int telefonoCliente { get; set; }

        [Required]
        [Display(Name = "Digite el DUI del Cliente")]
        public int duiCliente { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Digite el Correo del Cliente")]
        public string correoCliente { get; set; }

    }
}