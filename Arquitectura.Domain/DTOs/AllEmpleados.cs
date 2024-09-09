using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Domain.DTOs
{
    public class AllEmpleados
    {
        public int idEmpleado { get; set; }
        public int numeroEmpleado { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String telefono { get; set; }
        public String correo { get; set; }
        public String rfc { get; set; }
        public String domicilio { get; set; }
        public String ciudad { get; set; }
        public String estado { get; set; }
        public String pais { get; set; }
        public string filecv { get; set; }
    }
}
