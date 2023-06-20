using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRUDTApp
{
    internal class AddressTest
    {
        public static void Testing (SqlConnection connection)
        {
            AddressAdd(connection, "Krakow", "Ciemna", "102", "33-333");
            AddressConsoleLog(connection);
        }

        public static void AddressConsoleLog(SqlConnection connection)
        {
            string sql = (string)("SELECT ID, " +
                "address.City as City, " +
                "address.StreetName as StreetName, " +
                "address.HouseNumber as HouseNumber, " +
                "address.ZipCode as Zipcode " +
                "FROM dbo.Address");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== Address ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"] +
                        ", city: " + reader["City"] +
                        ", street name: " + reader["StreetName"] +
                        ", house number: " + reader["HouseNumber"] +
                        ", zip code: " + reader["ZipCode"]);
                }
            }
        }

        public static void AddressAdd(SqlConnection connection, string City, string StreetName, string HouseNumber, string ZipCode)
        {
            string sql = (string)("INSERT INTO Address VALUES ('" + City + "," + StreetName + "," + HouseNumber + "," + ZipCode + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void AddressRemove(SqlConnection connection, string id)
        {
            string sql = (string)("DELETE FROM Address WHERE id = " + id);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void AddressLog(SqlConnection connection, string id)
        {
            string sql = (string)("SELECT ID, " +
                "address.City as City, " +
                "address.StreetName as StreetName, " +
                "address.HouseNumber as HouseNumber, " +
                "address.ZipCode as Zipcode " +
                "FROM dbo.Address " +
                "WHERE ID = " + id);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== Address ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"] +
                        ", city: " + reader["City"] +
                        ", street name: " + reader["StreetName"] +
                        ", house number: " + reader["HouseNumber"] +
                        ", zip code: " + reader["ZipCode"]);
                }
            }
        }
    }
}
