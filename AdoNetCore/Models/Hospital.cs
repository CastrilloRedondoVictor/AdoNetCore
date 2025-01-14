using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCore.Models
{
    public class Hospital
    {
        public int Hospital_cod { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Num_cama { get; set; }

        public Hospital(int hospital_cod, string nombre, string direccion, string telefono, int num_cama)
        {
            this.Hospital_cod = hospital_cod;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Num_cama = num_cama;
        }

        public override string ToString()
        {
            return $"{Hospital_cod} - {Nombre} - {Direccion} - {Telefono} - {Num_cama}";
        }
    }
}
