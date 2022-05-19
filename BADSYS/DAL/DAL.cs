using MySql.Data.MySqlClient;

namespace DAL
{
    public class DAL
    {
        private static string connectionString = "";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        private static MySqlParameter GetParam(KeyValuePair<string, dynamic> parameter)
        {
            MySqlParameter param = new MySqlParameter
            {
                ParameterName = $"@{parameter.Key}",
                Value = parameter.Value
            };
            return param;
        }

        protected static bool ExecuteInsert(string sql, List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                foreach (KeyValuePair<string, dynamic> parameter in parameters)
                {
                    cmd.Parameters.Add(GetParam(parameter));
                }
                cmd.CommandText = sql;
                connection.Open();
                cmd.ExecuteScalar();

                return true;
            } catch (MySqlException ex)
            {
                Console.WriteLine($"Cannot open connection! ErrorCode: {ex.ErrorCode} Error: {ex.Message}");
                return false;
            } catch (Exception ex)
            {
                Console.WriteLine($"Cannot open connection! Error: {ex.Message}");
                return false;
            } finally
            {
                connection.Close();
            }
        }
    }
}