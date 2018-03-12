using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
           string connectionString = @"Data Source=CR5-00\SQLEXPRESS; Initial Catalog=Library; Integrated Security=sspi;";
            
            SqlConnection connection = new SqlConnection(connectionString);
            //или
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = connectionString;

            try
            {
                //Открываем соединение
                connection.Open();

                //Подготавливаем запрос
                String insertString = @"insert into authors (firstname,lastname)values('Leonel', 'Messi')";
                //Создаем обьект Command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = insertString;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
  
    }
}
