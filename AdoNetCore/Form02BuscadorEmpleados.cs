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
    public partial class Form02BuscadorEmpleados : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string connectionString;
        public Form02BuscadorEmpleados()
        {
            InitializeComponent();

            this.connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string salario = this.txtSalario.Text;
            string sql = "select * from EMP where salario >= " + salario;

            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            reader = this.cmd.ExecuteReader();

            this.lstEmpleados.Items.Clear();

            while (reader.Read())
            {
                this.lstEmpleados.Items.Add(reader["APELLIDO"].ToString() + " - " + reader["SALARIO"].ToString());
            }
            this.reader.Close();
            this.conn.Close();
        }

        private void btnBuscarOficio_Click(object sender, EventArgs e)
        {
            string oficio = this.txtOficio.Text;
            string sql = "select * from EMP where oficio = '" + oficio + "'";

            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            reader = this.cmd.ExecuteReader();

            this.lstEmpleados.Items.Clear();

            while (reader.Read())
            {
                this.lstEmpleados.Items.Add(reader["APELLIDO"].ToString() + " - " + reader["OFICIO"].ToString());
            }

            this.reader.Close();
            this.conn.Close();
        }
    }
}
