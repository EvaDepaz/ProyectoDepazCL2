using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDepazCL2.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "Debe ingresar código del cliente")]
        [Display(Name = "Código de cliente")]
        public string IdCliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar Nombre del cliente")]
        [Display(Name = "Nombre de Cliente")]
        public string NombreCia { get; set; }

        [Required(ErrorMessage = "Debe ingresar la dirección del cliente")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Código de país")]
        public string Idpais { get; set; }

        [Required(ErrorMessage = "Debe ingresar el teléfono del cliente")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

    }
}