using System.ComponentModel.DataAnnotations;

namespace Miguel_P1_AP2.Models
{
    public class Departamentos
    {
        [Key]
        [Required(ErrorMessage ="Este campo es obligario.")]
        public int DepartamentoId {get; set;}
        [Required(ErrorMessage ="Este campo es obligario.")]
        public string Descripcion {get; set;}

        public Departamentos(){
            DepartamentoId = 0;
            Descripcion = string.Empty;
        }
    }
}