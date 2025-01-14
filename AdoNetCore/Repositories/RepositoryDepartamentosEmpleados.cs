using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdoNetCore.Repositories
{
    public class RepositoryDepartamentosEmpleados
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public RepositoryDepartamentosEmpleados()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "select DNOMBRE from DEPT";

            this.cmd.Connection = this.conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            List<string> result = new List<string>();

            this.reader = await this.cmd.ExecuteReaderAsync();

            while(await this.reader.ReadAsync())
            {
                result.Add(this.reader["DNOMBRE"].ToString());
            }

            await this.conn.CloseAsync();
            await this.reader.CloseAsync();

            return result;
        }

        public async Task<List<string>> GetEmpleadosDepartamentoAsync(string departamento) {
            string sql = "select E.APELLIDO from EMP E join DEPT D on E.DEPT_NO=D.DEPT_NO where D.DNOMBRE=@departamento";

            this.cmd.Parameters.Add(new SqlParameter("@departamento", departamento));
            this.cmd.Connection = this.conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            this.reader = await this.cmd.ExecuteReaderAsync();
            List<string> result = new List<string>();

            while(await this.reader.ReadAsync())
            {
                result.Add(this.reader["APELLIDO"].ToString());
            }

            await this.conn.CloseAsync();
            this.cmd.Parameters.Clear();
            await this.reader.CloseAsync();

            return result;

        }

        public async void DeleteEmpleadoAsync(string apellido)
        {
            string sql = "delete from EMP where APELLIDO=@apellido";

            this.cmd.Parameters.Add(new SqlParameter("@apellido", apellido));
            this.cmd.Connection = this.conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
        }

    }
}
