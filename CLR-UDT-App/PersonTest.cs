using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRUDTApp
{
    internal class PersonTest
    {
        public static void Testing (SqlConnection connection)
        {
            PersonAdd(connection, "Test", "Testowy", "10.10.2000 12:42:12");
            PersonConsoleLog(connection);
        }

        public static void PersonConsoleLog(SqlConnection connection)
        {
            string sql = (string)("SELECT ID, " +
                "person.FirstName as firstname, " +
                "person.LastName as lastname, " +
                "person.BirthDate as birthdate " +
                "FROM dbo.Person");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== Person ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"] +
                        ", first name: " + reader["firstname"] +
                        ", last name: " + reader["lastname"] +
                        ", birth date: " + reader["birthdate"]);
                }
            }
        }

        public static void PersonAdd(SqlConnection connection, string FirstName, string LastName, string BirthDate)
        {
            string sql = (string)("INSERT INTO Person VALUES ('" + FirstName + "," + LastName + "," + BirthDate + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void PersonRemove(SqlConnection connection, string id)
        {
            string sql = (string)("DELETE FROM Person WHERE id = " + id);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void PersonLog(SqlConnection connection, string id)
        {
            string sql = (string)("SELECT ID, " +
                "person.FirstName as firstname, " +
                "person.LastName as lastname, " +
                "person.BirthDate as birthdate " +
                "FROM dbo.Person " +
                "WHERE ID = " + id);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== Person ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"] +
                        ", first name: " + reader["firstname"] +
                        ", last name: " + reader["lastname"] +
                        ", birth date: " + reader["birthdate"]);
                }
            }
        }
    }
}
