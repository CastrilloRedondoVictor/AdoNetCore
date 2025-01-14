using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCore.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCore.Repositories
{
    public class RepositoryHospitales
    {
        public SqlConnection conn;
        public SqlCommand cmd;
        private SqlDataReader reader;

        public RepositoryHospitales()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "select * from HOSPITAL";

            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            this.reader = await this.cmd.ExecuteReaderAsync();
            List<Hospital> result = new List<Hospital>();

            while (await this.reader.ReadAsync())
            {
                result.Add(new Hospital(int.Parse(this.reader["HOSPITAL_COD"].ToString()), this.reader["NOMBRE"].ToString(), this.reader["DIRECCION"].ToString(), this.reader["TELEFONO"].ToString(), int.Parse(this.reader["NUM_CAMA"].ToString())));
            }

            await this.conn.CloseAsync();
            await this.reader.CloseAsync();

            return result;
        }

        public async void InsertHospitalAsync(int hospital_cod, string nombre, string direccion, string telefono, int num_cama)
        {
            string sql = "insert into HOSPITAL values(@hospital_cod, @nombre, @direccion, @telefono, @num_cama)";

            this.cmd.Parameters.Add(new SqlParameter("@hospital_cod", hospital_cod));
            this.cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            this.cmd.Parameters.Add(new SqlParameter("@direccion", direccion));
            this.cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
            this.cmd.Parameters.Add(new SqlParameter("@num_cama", num_cama));

            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
            this.cmd.Parameters.Clear();
        }

        public async void UpdateHospitalsAsync(int hospital_cod, string nombre, string direccion, string telefono, int num_cama)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre, DIRECCION=@direccion, TELEFONO=@telefono, NUM_CAMA=@num_cama where HOSPITAL_COD=@hospital_cod";

            this.cmd.Parameters.Add(new SqlParameter("@hospital_cod", hospital_cod));
            this.cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            this.cmd.Parameters.Add(new SqlParameter("@direccion", direccion));
            this.cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
            this.cmd.Parameters.Add(new SqlParameter("@num_cama", num_cama));

            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
            this.cmd.Parameters.Clear();
        }

        public async void DeleteHospitalsAsync(int hospital_cod)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD=@hospital_cod";

            this.cmd.Parameters.Add(new SqlParameter("@hospital_cod", hospital_cod));

            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
            this.cmd.Parameters.Clear();
        }
    }
}
