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
    public partial class Form06UpdateSalasClases : Form
    {

        private RepositorySalas respositorySalas;

        public Form06UpdateSalasClases()
        {
            InitializeComponent();

            this.respositorySalas = new RepositorySalas();
            this.LoadSalas();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int result = await this.respositorySalas.SetNombreSalaAsync(this.lstSalas.SelectedItem.ToString(), this.txtNueva.Text);
            MessageBox.Show("Campos modificados: " + result);
            this.LoadSalas();
        }

        private async void LoadSalas()
        {
            List<string> result = await this.respositorySalas.GetNombresSalaAsync();
            this.lstSalas.Items.Clear();

            foreach (string sala in result) { 
                lstSalas.Items.Add(sala);
            }
        }
    }
}
