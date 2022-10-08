using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1_3.Modelos
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string nombres { get; set; }
        [MaxLength(50)]
        public string apellidos { get; set; }
        public int edad { get; set; }
        [MaxLength(100)]
        public string correo { get; set; }
        [MaxLength(250)]
        public string direccion { get; set; }
    }
}
