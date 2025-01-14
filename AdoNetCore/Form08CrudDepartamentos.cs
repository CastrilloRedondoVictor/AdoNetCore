using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCore.Models;
using AdoNetCore.Repositories;

namespace AdoNetCore
{
    public partial class Form08CrudDepartamentos : Form
    {

        RepositoryDepartamentos repository;
        public Form08CrudDepartamentos()
        {
            InitializeComponent();

            this.repository = new RepositoryDepartamentos();
            this.getDepartamentos();
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            this.repository.InsertDepartamentoAsync(int.Parse(this.txtId.Text), this.txtNombre.Text, this.txtLocalidad.Text);

            MessageBox.Show("Departamento " + this.txtId.Text + " añadido.");
            this.getDepartamentos();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.repository.UpdateDepartamentoAsync(int.Parse(this.txtId.Text), this.txtNombre.Text, this.txtLocalidad.Text);
            MessageBox.Show("Departamento " + this.txtId.Text + " actualizado.");
            this.getDepartamentos();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            this.repository.DeleteDepartamentoAsync(int.Parse(this.txtId.Text));


            MessageBox.Show("Departamento " + this.txtId.Text + " eliminado.");
            this.getDepartamentos();
        }


        private async void getDepartamentos()
        {
            this.lstDepartamentos.Items.Clear();
            List<Departamento> departamentos = await this.repository.GetDepartamentosAsync();
            foreach (var departamento in departamentos)
            {
                this.lstDepartamentos.Items.Add(departamento);
            }
            this.cleanBoxes();
        }

        private void cleanBoxes()
        {
            this.txtId.Clear();
            this.txtNombre.Clear();
            this.txtLocalidad.Clear();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtId.Text = this.lstDepartamentos.SelectedItem.ToString().Split('-')[0].Trim();
            this.txtNombre.Text = this.lstDepartamentos.SelectedItem.ToString().Split('-')[1].Trim();
            this.txtLocalidad.Text = this.lstDepartamentos.SelectedItem.ToString().Split('-')[2].Trim();
        }
    }
}
