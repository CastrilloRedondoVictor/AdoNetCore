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
    public partial class Form09CrudHospitales : Form
    {
        RepositoryHospitales repository;
        public Form09CrudHospitales()
        {
            InitializeComponent();

            this.repository = new RepositoryHospitales();
            this.GetHospitales();
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            this.repository.InsertHospitalAsync(int.Parse(this.txtId.Text), this.txtNombre.Text, this.txtDireccion.Text, this.txtTelefono.Text, int.Parse(this.txtCamas.Text));
            MessageBox.Show("Hospital " + this.txtId.Text + " añadido.");
            this.GetHospitales();
        }


        private async void GetHospitales()
        {
            List<Hospital> hospitales = await this.repository.GetHospitalesAsync();

            this.lstHospitales.DataSource = hospitales;

            this.ClearBoxes();
        }

        private void ClearBoxes()
        {
            this.txtNombre.Clear();
            this.txtId.Clear();
            this.txtTelefono.Clear();
            this.txtCamas.Clear();
            this.txtDireccion.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.repository.UpdateHospitalsAsync(int.Parse(this.txtId.Text), this.txtNombre.Text, this.txtDireccion.Text, this.txtTelefono.Text, int.Parse(this.txtCamas.Text));
            MessageBox.Show("Hospital " + this.txtId.Text + " modificado.");
            this.GetHospitales();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.repository.DeleteHospitalsAsync(int.Parse(this.txtId.Text));
            MessageBox.Show("Hospital " + this.txtId.Text + " eliminado.");
            this.GetHospitales();
        }

        private void lstHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearBoxes();
            this.txtId.Text = this.lstHospitales.SelectedItem.ToString().Split('-')[0].Trim();
            this.txtNombre.Text = this.lstHospitales.SelectedItem.ToString().Split('-')[1].Trim();
            this.txtDireccion.Text = this.lstHospitales.SelectedItem.ToString().Split('-')[2].Trim();
            this.txtTelefono.Text = this.lstHospitales.SelectedItem.ToString().Split('-')[3].Trim() + "-" + this.lstHospitales.SelectedItem.ToString().Split('-')[4].Trim();
            this.txtCamas.Text = this.lstHospitales.SelectedItem.ToString().Split('-')[5].Trim();
        }
    }
}
