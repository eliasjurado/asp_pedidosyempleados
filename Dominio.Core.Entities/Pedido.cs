using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Pedido
    {
        [Display(Name = "Codigo Pedido")]
        [Required(ErrorMessage = "Ingrese código")]
        public Int32 idped { get; set; }
        [Display(Name = "Fecha Pedido")]
        [Required(ErrorMessage = "Ingrese fecha de pedido")]
        public DateTime fechaped { get; set; }
        [Display(Name = "Codigo Empleado")]
        [Required(ErrorMessage = "Seleccione un empleado")]
        public Int32 idempleado { get; set; }
        [Display(Name = "Detalle de Pedido")]
        [Required(ErrorMessage = "Ingrese detalle de pedido")]
        public string detped { get; set; }
        [Display(Name = "Costo de Pedido")]
        [Required(ErrorMessage = "Ingrese costo de pedido")]
        public decimal costoped { get; set; }
    }
}
