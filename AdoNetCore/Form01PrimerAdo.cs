using System.Data;
using System.Data.SqlClient;

namespace AdoNetCore
{
    public partial class Form01PrimerAdo : Form
    {

        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        string connectionString;
        public Form01PrimerAdo()
        {
            InitializeComponent();

            this.connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();
            this.cn.StateChange += Cn_StateChange;
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            this.lblMensaje.Text = "La conexión ha pasado de " + e.OriginalState
                + " a " + e.CurrentState;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cn.State == System.Data.ConnectionState.Closed)
                {
                    this.cn.Open();
                }
                this.lblMensaje.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            this.cn.Close();
            this.lblMensaje.BackColor = Color.Red;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string sql = "select * from EMP";

            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.reader = this.com.ExecuteReader();

            this.ClearBoxes();

            for (int i = 0; i < this.reader.FieldCount; i++)
            {
                this.lstColumnas.Items.Add(this.reader.GetName(i));
                this.lstTiposDato.Items.Add(this.reader.GetDataTypeName(i));
            }

            while (this.reader.Read())
            {
                this.lstApellidos.Items.Add(this.reader["APELLIDO"].ToString());
            }

            this.reader.Close();
        }

        private void ClearBoxes()
        {
            this.lstApellidos.Items.Clear();
            this.lstColumnas.Items.Clear();
            this.lstTiposDato.Items.Clear();
        }
    }
}
