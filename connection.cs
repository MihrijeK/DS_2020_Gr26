using System;

using MySql.Data.MySqlClient;

namespace ds
{
    public class Connection
    {
        public static MySqlDataReader databaza(string sql)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=users;userid=root;password=password123.");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                return reader;

            }


            catch (Exception exeption)
            {
                throw new Exception(exeption.Message);
            }
        }

    }
}
