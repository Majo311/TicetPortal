using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TicetPortal.Models;

namespace TicetPortal.Others
{
    public class MsSqlAdoNet_Reader
    {
        public string ConnectionString { get; set; }
        public IConfiguration _configuration;
       
        public MsSqlAdoNet_Reader(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConnectionString= this._configuration.GetConnectionString("DBConnection");
        }

        public DataSet GetStoredProcedureResult(string ProcedureName,string ParameterToSearch) 
        {
            DataSet dataSetResult = new DataSet();
            try
            {
                using(var connection=new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(ProcedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Parameter", ParameterToSearch));  
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand= cmd;
                    adapter.Fill(dataSetResult);
                }
            }
            catch 
            {
                return null;
            }
            return dataSetResult;
        }
    }
}