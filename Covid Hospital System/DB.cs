using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
public class DB
{
    DataSet ds;
    public DB()
    {
        ds = new DataSet();
    }
    public string QueryScalar(string Query, params object[] parameters)
    {
        string? str;
        MySqlConnection mySqlConnection = new(ConfigurationManager.ConnectionStrings["Constring"].ToString());
        MySqlCommand mySqlCommand = new(Query, mySqlConnection);
        if (parameters != null && parameters.Length > 0)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                mySqlCommand.Parameters.AddWithValue($"@param{i + 1}", parameters[i]);
            }
        }
        mySqlConnection.Open();
        try
        {
            try
            {
                object result = mySqlCommand.ExecuteScalar();
                str = result != null ? result.ToString() : null;

            }
            finally
            {
                mySqlCommand.Dispose();
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return str;
    }

}