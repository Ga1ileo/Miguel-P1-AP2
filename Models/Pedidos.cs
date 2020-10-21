using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Miguel_P1_AP2.Models
{
    public class Pedidos
    {
        [Key]
        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public int PedidoId {get;set;}

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public DateTime Fecha {get;set;}

        [ForeignKey("PedidoId")]
        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public int ArticuloId{get;set;}

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public decimal Precio {get;set;}

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public int Cantidad {get;set;}

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public decimal Total {get;set;}
        

        public Pedidos(){

            PedidoId = 0;
            Fecha = DateTime.Now;
            ArticuloId = 0;
            Precio = 0;
            Cantidad = 0;
            Total = 0;

        }



    }
}