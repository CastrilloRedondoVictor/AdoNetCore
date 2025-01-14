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
    public partial class Form05ModificarSalas : Form
    {

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        string connectionString;

        public Form05ModificarSalas()
        {
            InitializeComponent();

            this.connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();

            this.GetSalas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSala = int.Parse(this.lstSalas.SelectedItem.ToString().Split('-')[0].Trim());
            string nombre = this.txtNueva.Text;

            string sql = "update SALA set NOMBRE=@nombre WHERE SALA_COD=@idSala";

            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            SqlParameter pamId = new SqlParameter("@idSala", idSala);

            this.cmd.Parameters.Add(pamNombre);
            this.cmd.Parameters.Add(pamId);
            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.conn.Open();

            int editados = this.cmd.ExecuteNonQuery();

            this.conn.Close();

            this.GetSalas();


        }

        private void GetSalas()
        {
            string sql = "select * from SALA";

            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            this.lstSalas.Items.Clear();

            this.conn.Open();

            this.rdr = this.cmd.ExecuteReader();

            while (this.rdr.Read())
            {
                this.lstSalas.Items.Add(this.rdr["SALA_COD"] + " - " + this.rdr["NOMBRE"]);
            }

            this.conn.Close ();
        }
    }
}
