using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRUDTApp
{
    internal class ProductTest
    {
        public static void Testing (SqlConnection connection)
        {
            ProductAdd(connection, "Piłka", "12", "Czerwona");
            ProductConsoleLog(connection);
        }

        public static void ProductConsoleLog(SqlConnection connection)
        {
            string sql = (string)("SELECT Product.ID, " +
                "Product.Name as Name, " +
                "Product.Price as Price, " +
                "Product.Description as Description " +
                "FROM dbo.Product");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== Product ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"] +
                        ", name: " + reader["Name"] +
                        ", price: " + reader["Price"] +
                        ", description: " + reader["Description"]);
                }
            }
        }

        public static void ProductAdd(SqlConnection connection, string Name, string Price, string Description)
        {
            string sql = (string)("INSERT INTO Product VALUES ('" + Name + "," + Price + "," + Description + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void ProductRemove(SqlConnection connection, string id)
        {
            string sql = (string)("DELETE FROM Product WHERE id = " + id);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void ProductLog(SqlConnection connection, string id)
        {
            string sql = (string)("SELECT Product.ID, " +
                "Product.Name as Name, " +
                "Product.Price as Price, " +
                "Product.Description as Description " +
                "FROM dbo.Product " +
                "WHERE Product.ID = " + id);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== Product ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"] +
                        ", name: " + reader["Name"] +
                        ", price: " + reader["Price"] +
                        ", description: " + reader["Description"]);
                }
            }
        }
    }
}
