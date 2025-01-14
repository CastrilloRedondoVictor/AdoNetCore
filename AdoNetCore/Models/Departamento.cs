using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCore.Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }

        public Departamento(int idDepartamento, string nombre, string localidad)
        {
            this.IdDepartamento = idDepartamento;
            this.Nombre = nombre;
            this.Localidad = localidad;
        }

        public override string ToString()
        {
            return $"{IdDepartamento} - {Nombre} - {Localidad}";
        }
    }
}
