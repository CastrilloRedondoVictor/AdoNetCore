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
    public partial class Form03EliminarEnfermos : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string connectionString;

        public Form03EliminarEnfermos()
        {
            InitializeComponent();

            this.connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();

            this.GetEnfermos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string sql = "delete from ENFERMO where INSCRIPCION=@inscripcion";
            SqlParameter pamInscripcion = new SqlParameter("@inscripcion", int.Parse(this.txtInscripcion.Text));

            this.cmd.Parameters.Add(pamInscripcion);
            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            int eliminados = this.cmd.ExecuteNonQuery();

            this.conn.Close();

            MessageBox.Show("Registros eliminados: " + eliminados);
            this.GetEnfermos();
        }

        private void GetEnfermos()
        {
            string sql = "select * from ENFERMO";

            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            this.reader = this.cmd.ExecuteReader();

            this.lstEnfermos.Items.Clear();

            while (this.reader.Read())
            {
                this.lstEnfermos.Items.Add(this.reader["INSCRIPCION"].ToString() + " - " + this.reader["APELLIDO"].ToString());
            }
            this.reader.Close();
            this.conn.Close();
        }
    }
}
