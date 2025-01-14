using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCore.Repositories;

namespace AdoNetCore
{
    public partial class Form07DepartamentosEmpleados : Form
    {

        private RepositoryDepartamentosEmpleados repository;

        public Form07DepartamentosEmpleados()
        {
            InitializeComponent();

            this.repository = new RepositoryDepartamentosEmpleados();
            this.LoadDepartamentos();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadEmpleados();
        }

        private async void LoadDepartamentos()
        {
            List<string> departamentos = await this.repository.GetDepartamentosAsync();

            foreach (string departamento in departamentos)
            {
                this.lstDepartamentos.Items.Add(departamento);
            }
        }

        private async void LoadEmpleados()
        {
            List<string> empleados = await this.repository.GetEmpleadosDepartamentoAsync(this.lstDepartamentos.SelectedItem.ToString());
            this.lstEmpleados.Items.Clear();

            foreach (string empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string apellido = this.lstEmpleados.SelectedItem.ToString();
            this.repository.DeleteEmpleadoAsync(apellido);
            MessageBox.Show(apellido + " ha sido eliminado.");
            this.LoadEmpleados();
        }
    }
}
