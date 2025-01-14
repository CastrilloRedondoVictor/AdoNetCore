using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdoNetCore.Repositories
{

    
    public class RepositorySalas
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public RepositorySalas()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();
        }

        public async Task<List<string>> GetNombresSalaAsync()
        {
            string sql = "select distinct NOMBRE from SALA";

            this.cmd.Connection = this.conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            this.reader = await this.cmd.ExecuteReaderAsync();

            List<string> result = new List<string>();

            while (this.reader.Read()) { 
                result.Add(this.reader["NOMBRE"].ToString());
            }

            await this.reader.CloseAsync();
            await this.conn.CloseAsync();

            return result;
        }

        public async Task<int> SetNombreSalaAsync(string oldName, string newName)
        {
            string sql = "update SALA set NOMBRE=@newName where NOMBRE=@oldName";

            SqlParameter pamOldName = new SqlParameter("@oldName", oldName);
            SqlParameter pamNewName = new SqlParameter("@newName", newName);

            this.cmd.Parameters.Add(pamOldName);
            this.cmd.Parameters.Add(pamNewName);

            this.cmd.Connection = this.conn;
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            await this.conn.OpenAsync();

            int result = await this.cmd.ExecuteNonQueryAsync();

            await this.conn.CloseAsync();

            this.cmd.Parameters.Clear();

            return result;
        }
    }
}
