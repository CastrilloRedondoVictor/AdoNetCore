using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCore.Models;
using Microsoft.Data.SqlClient;

namespace AdoNetCore.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;

        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string sql = "select * from DEPT";

            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            this.reader = await this.cmd.ExecuteReaderAsync();
            List<Departamento> departamentos = new List<Departamento>();

            while (await this.reader.ReadAsync()) {
                departamentos.Add(new Departamento(int.Parse(this.reader["DEPT_NO"].ToString()), this.reader["DNOMBRE"].ToString(), this.reader["LOC"].ToString()));
            }

            await this.conn.CloseAsync();
            await this.reader.CloseAsync();

            return departamentos;
        }

        public async void InsertDepartamentoAsync(int dept_no, string dnombre, string loc)
        {
            string sql = "insert into DEPT values(@dept_no, @dnombre, @loc)";

            this.cmd.Parameters.Add(new SqlParameter("@dept_no", dept_no));
            this.cmd.Parameters.Add(new SqlParameter("@dnombre", dnombre));
            this.cmd.Parameters.Add(new SqlParameter("@loc", loc));
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
            await this.reader.CloseAsync();
            this.cmd.Parameters.Clear();
        }

        public async void UpdateDepartamentoAsync(int dept_no, string dnombre, string loc)
        {
            string sql = "update DEPT set DNOMBRE=@dnombre, LOC=@loc  where DEPT_NO=@dept_no";

            this.cmd.Parameters.Add(new SqlParameter("@dept_no", dept_no));
            this.cmd.Parameters.Add(new SqlParameter("@dnombre", dnombre));
            this.cmd.Parameters.Add(new SqlParameter("@loc", loc));
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
            await this.reader.CloseAsync();
            this.cmd.Parameters.Clear();
        }

        public async void DeleteDepartamentoAsync(int dept_no)
        {
            string sql = "delete from DEPT where DEPT_NO=@dept_no";

            this.cmd.Parameters.Add(new SqlParameter("@dept_no", dept_no));
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();
            await this.reader.CloseAsync();
            this.cmd.Parameters.Clear();
        }
    }
}
