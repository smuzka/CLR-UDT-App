using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRUDTApp
{
    internal class CompanyTest
    {
        public static void Testing (SqlConnection connection)
        {
            CompanyAdd(connection, "AGH", "123456789", "987654321", "Krakow", "Ciemna", "102", "33-333");
            CompanyConsoleLog(connection);
        }

        public static void CompanyConsoleLog(SqlConnection connection)
        {
            string sql = (string)("SELECT Company.ID as CompanyID, " +
                "Company.Name as Name, " +
                "Company.NIP as NIP, " +
                "Company.REGON as REGON, " +
                "Company.AddressId as AddressId, " +
                "Address.City as City, " +
                "Address.StreetName as StreetName, " +
                "Address.HouseNumber as HouseNumber, " +
                "Address.ZipCode as ZipCode " +
                "FROM dbo.Company " +
                "JOIN dbo.Address ON Company.AddressId = Address.ID");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== COMPANY ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["CompanyID"] +
                        ", name: " + reader["Name"] +
                        ", NIP: " + reader["NIP"] +
                        ", REGON: " + reader["REGON"] +
                        ", addressId: " + reader["AddressId"] +
                        ", city: " + reader["City"] +
                        ", street name: " + reader["StreetName"] +
                        ", house number: " + reader["HouseNumber"] +
                        ", zip code: " + reader["ZipCode"]);
                }
            }
        }

        public static void CompanyAdd(SqlConnection connection, string Name, string NIP, string REGON, string City, string StreetName, string HouseNumber, string ZipCode )
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

            string sql = (string)("INSERT INTO Company VALUES ('" + Name + "," + NIP + "," + REGON + "," + addressId + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void CompanyAddAddressId(SqlConnection connection, string Name, string NIP, string REGON, string addressId)
        {
            string sql = (string)("INSERT INTO Company VALUES ('" + Name + "," + NIP + "," + REGON + "," + addressId + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        public static void CompanyRemove(SqlConnection connection, string id)
        {
            string sql = (string)("DELETE FROM Company WHERE id = " + id);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void CompanyLog(SqlConnection connection, string id)
        {
            string sql = (string)("SELECT Company.ID as CompanyID, " +
                "Company.Name as Name, " +
                "Company.NIP as NIP, " +
                "Company.REGON as REGON, " +
                "Company.AddressId as AddressId, " +
                "Address.City as City, " +
                "Address.StreetName as StreetName, " +
                "Address.HouseNumber as HouseNumber, " +
                "Address.ZipCode as ZipCode " +
                "FROM dbo.Company " +
                "JOIN dbo.Address ON Company.AddressId = Address.ID " +
                "WHERE Company.ID = " + id);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== COMPANY ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["CompanyID"] +
                        ", name: " + reader["Name"] +
                        ", NIP: " + reader["NIP"] +
                        ", REGON: " + reader["REGON"] +
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
