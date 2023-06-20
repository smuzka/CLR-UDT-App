using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRUDTApp
{
    internal class OrderTest
    {
        public static void Testing (SqlConnection connection)
        {
            OrderAdd(connection, "71239893", "01.01.2001 01:01:01", "Pszczyna", "Pszczela", "444", "44-123");
            OrderConsoleLog(connection);
        }

        public static void OrderConsoleLog(SqlConnection connection)
        {
            string sql = (string)("SELECT orders.ID as OrderId, " +
                "orders.OrderNumber as OrderNumber, " +
                "orders.Date as Date, " +
                "orders.AddressId as AddressId, " +
                "Address.City as City, " +
                "Address.StreetName as StreetName, " +
                "Address.HouseNumber as HouseNumber, " +
                "Address.ZipCode as ZipCode " +
                "FROM orders " +
                "JOIN address ON orders.AddressId = address.ID");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== ORDERS ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["OrderId"] +
                        ", OrderNumber: " + reader["OrderNumber"] +
                        ", Date: " + reader["Date"] +
                        ", addressId: " + reader["AddressId"] +
                        ", city: " + reader["City"] +
                        ", street name: " + reader["StreetName"] +
                        ", house number: " + reader["HouseNumber"] +
                        ", zip code: " + reader["ZipCode"]);
                }
            }
        }

        public static void OrderAdd(SqlConnection connection, string OrderNumber, string Date, string City, string StreetName, string HouseNumber, string ZipCode)
        {
            // Create Address opbject
            AddressTest.AddressAdd(connection, City, StreetName, HouseNumber, ZipCode);
            // Find Id of created object
            string selectSql = (string)("SELECT TOP 1 ID FROM dbo.Address ORDER BY ID DESC");
            SqlCommand SelectCommand = new SqlCommand(selectSql, connection);
            SelectCommand.ExecuteNonQuery();
            int addressId;

            using (SqlDataReader reader = SelectCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    addressId = reader.GetInt32(0);
                }
                else
                {
                    addressId = 0;
                }
            }

            string sql = (string)("INSERT INTO Orders VALUES ('" + OrderNumber + "," + Date + "," + addressId + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void OrderAddAddressId(SqlConnection connection, string OrderNumber, string Date, string addressId)
        {
            string sql = (string)("INSERT INTO Orders VALUES ('" + OrderNumber + "," + Date + "," + addressId + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void OrderRemove(SqlConnection connection, string id)
        {
            string sql = (string)("DELETE FROM Order WHERE id = " + id);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void OrderLog(SqlConnection connection, string id)
        {
            string sql = (string)("SELECT orders.ID as OrderId, " +
                "orders.OrderNumber as OrderNumber, " +
                "orders.Date as Date, " +
                "orders.AddressId as AddressId, " +
                "Address.City as City, " +
                "Address.StreetName as StreetName, " +
                "Address.HouseNumber as HouseNumber, " +
                "Address.ZipCode as ZipCode " +
                "FROM orders " +
                "JOIN address ON orders.AddressId = address.ID " +
                "WHERE orders.ID = " + id);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== ORDERS ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["OrderId"] +
                        ", OrderNumber: " + reader["OrderNumber"] +
                        ", Date: " + reader["Date"] +
                        ", addressId: " + reader["AddressId"] +
                        ", city: " + reader["City"] +
                        ", street name: " + reader["StreetName"] +
                        ", house number: " + reader["HouseNumber"] +
                        ", zip code: " + reader["ZipCode"]);
                }
            }
        }
    }
}
