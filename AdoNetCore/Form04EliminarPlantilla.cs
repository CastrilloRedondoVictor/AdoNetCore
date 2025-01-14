using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AdoNetCore
{
    public partial class Form04EliminarPlantilla : Form
    {

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        string connectionString;

        public Form04EliminarPlantilla()
        {
            InitializeComponent();

            this.connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();

            this.GetPlantilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string sql = "delete from PLANTILLA where EMPLEADO_NO=" + this.txtId.Text;

            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            int eliminados = this.cmd.ExecuteNonQuery();

            this.conn.Close();

            MessageBox.Show("Registros eliminados: " + eliminados);
            this.txtId.Clear();
            this.GetPlantilla();
        }

        private void GetPlantilla()
        {
            string sql = "select * from PLANTILLA";

            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            this.rdr = this.cmd.ExecuteReader();

            this.lstPlantilla.Items.Clear();

            while (rdr.Read())
            {
                this.lstPlantilla.Items.Add(rdr["APELLIDO"].ToString() + " - " + rdr["EMPLEADO_NO"].ToString());
            }

            this.conn.Close();

        }

        private void lstPlantilla_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtId.Text = this.lstPlantilla.SelectedItem.ToString().Split("-")[1].Trim();
        }
    }
}
