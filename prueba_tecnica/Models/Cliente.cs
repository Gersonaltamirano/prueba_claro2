using System;
using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}