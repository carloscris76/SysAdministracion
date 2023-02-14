using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdministracion.EntidadesDeNegocio
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(60,ErrorMessage ="Maximo 60 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "DUI es obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string DUI { get; set; }
        [Required(ErrorMessage = "Area es obligatorio")]
        public byte Area { get; set; }
        [Required(ErrorMessage ="Cargo es obligatorio")]
        public byte Cargo { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
    public enum Area_Empleado
    {
        RECURSOS_HUMANOS = 1,
        IT = 2,
        MANTENIMIENTO = 3
    }
    public enum Cargo_Empleado
    {
        ADMINISTRADOR_DE_REDES =1,
        DESARROLLADOR = 2,
        MANTENIMINETO = 3,
        ELECTRICISTA = 4,
        ENCARGADO_DE_LIMPIEZA = 5
    }
}
