using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDataReaderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=CR5-00\SQLEXPRESS; Initial Catalog=Library; Integrated Security=sspi;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader reader;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from authors", connection);
                reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    // fieldCount - количество полей
                    for (; i < reader.FieldCount; i++)
                    {
                        //Получить имя поля
                        Console.Write(reader.GetName(i).ToString()+" ");
                    }
                    Console.WriteLine("\n");

                    //Console.WriteLine(reader[0]+ " "+ reader[1]+ " "+reader[2]);
                    Console.WriteLine(reader["id"] + " " + reader["firstname"] + " " + reader["lastname"]);
                }
            }
            finally
            {
                connection.Close();
            }

            Console.Read();
        }
    }
}
