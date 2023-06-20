using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRUDTApp
{
    internal class BankAccountTest
    {
        public static void Testing (SqlConnection connection)
        {
            BankAccountAdd(connection, "71239893", "12", "Jan", "Kowalski", "01.01.2001 01:01:01");
            BankAccountConsoleLog(connection);
        }

        public static void BankAccountConsoleLog(SqlConnection connection)
        {
            string sql = (string)("SELECT bankAccount.ID as BankAccountID, " +
                "bankAccount.AccountNumber as AccountNumber, " +
                "bankAccount.Saldo as Saldo, " +
                "bankAccount.PersonId as PersonId, " +
                "person.FirstName as firstname, " +
                "person.LastName as lastname, " +
                "person.BirthDate as birthdate " +
                "FROM bankAccount " +
                "JOIN person ON bankAccount.PersonId = person.ID");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== BANK ACCOUNT ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["BankAccountID"] +
                        ", AccountNumber: " + reader["AccountNumber"] +
                        ", Saldo: " + reader["Saldo"] +
                        ", PersonId: " + reader["PersonId"] +
                        ", First name: " + reader["FirstName"] +
                        ", Last name: " + reader["LastName"] +
                        ", Birth date: " + reader["BirthDate"]);
                }
            }
        }

        public static void BankAccountAdd(SqlConnection connection, string AccountNumber, string Saldo, string FirstName, string LastName, string BirthDate )
        {
            // Create Address opbject
            PersonTest.PersonAdd(connection, FirstName, LastName, BirthDate);
            // Find Id of created object
            string selectSql = (string)("SELECT TOP 1 ID FROM dbo.Person ORDER BY ID DESC");
            SqlCommand SelectCommand = new SqlCommand(selectSql, connection);
            SelectCommand.ExecuteNonQuery();
            int personId;

            using (SqlDataReader reader = SelectCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    personId = reader.GetInt32(0);
                }
                else
                {
                    personId = 0;
                }
            }

            string sql = (string)("INSERT INTO BankAccount VALUES ('" + AccountNumber + "," + Saldo + "," + personId + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void BankAccountAddPersonId(SqlConnection connection, string AccountNumber, string Saldo, string personId)
        {
            string sql = (string)("INSERT INTO BankAccount VALUES ('" + AccountNumber + "," + Saldo + "," + personId + "')");
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void BankAccountRemove(SqlConnection connection, string id)
        {
            string sql = (string)("DELETE FROM BankAccount WHERE id = " + id);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static void BankAccountLog(SqlConnection connection, string id)
        {
            string sql = (string)("SELECT bankAccount.ID as BankAccountID, " +
                "bankAccount.AccountNumber as AccountNumber, " +
                "bankAccount.Saldo as Saldo, " +
                "bankAccount.PersonId as PersonId, " +
                "person.FirstName as firstname, " +
                "person.LastName as lastname, " +
                "person.BirthDate as birthdate " +
                "FROM bankAccount " +
                "JOIN person ON bankAccount.PersonId = person.ID " +
                "WHERE bankAccount.ID = " + id);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("=========== BANK ACCOUNT ===========");
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["BankAccountID"] +
                        ", AccountNumber: " + reader["AccountNumber"] +
                        ", Saldo: " + reader["Saldo"] +
                        ", PersonId: " + reader["PersonId"] +
                        ", First name: " + reader["FirstName"] +
                        ", Last name: " + reader["LastName"] +
                        ", Birth date: " + reader["BirthDate"]);
                }
            }
        }
    }
}
