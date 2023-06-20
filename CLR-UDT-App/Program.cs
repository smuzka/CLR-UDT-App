using System;
using System.Data.SqlClient;
using CLRUDTApp;

namespace ConnectingToSQLServer
{
    class Program
    {


        static void Main(string[] args)
        {

            string connString = @"Data Source = DESKTOP - Q40UGDL; Initial Catalog = BD2; INTEGRATED SECURITY=SSPI; Server =(local)";

            //create instanace of database connection
            SqlConnection connection = new SqlConnection(connString);

            try
            {
                connection.Open();

                PersonTest.Testing(connection);
                AddressTest.Testing(connection);
                CompanyTest.Testing(connection);
                BankAccountTest.Testing(connection);
                ProductTest.Testing(connection);
                OrderTest.Testing(connection);

                Console.WriteLine("====================================");
                Console.WriteLine("Choose option - enter 'exit' to exit");
                Console.WriteLine("====================================");
                Console.WriteLine("1 - add object");
                Console.WriteLine("2 - remove object");
                Console.WriteLine("3 - get object by id");
                Console.WriteLine("4 - get all objects");
                string firstOption;

                while ((firstOption = Console.ReadLine()) != "exit")
                {
                    switch (firstOption)
                    {
                        case "1":
                            Console.WriteLine("Choose option:");
                            Console.WriteLine("1 - Person");
                            Console.WriteLine("2 - Address");
                            Console.WriteLine("3 - BankAccount");
                            Console.WriteLine("4 - Company");
                            Console.WriteLine("5 - Product");
                            Console.WriteLine("6 - Order");

                            string ObjectToAdd = Console.ReadLine();
                            string[] DataToAdd;
                            switch (ObjectToAdd)
                            {
                                case "1":
                                    Console.WriteLine("Type first name, last name and birth date seperated by comma");
                                    DataToAdd = Console.ReadLine().Split(',');
                                    PersonTest.PersonAdd(connection, DataToAdd[0], DataToAdd[1], DataToAdd[2]);
                                    break;
                                case "2":
                                    Console.WriteLine("Type city, street name, house number and zip code seperated by comma");
                                    DataToAdd = Console.ReadLine().Split(',');
                                    AddressTest.AddressAdd(connection, DataToAdd[0], DataToAdd[1], DataToAdd[2], DataToAdd[3]);
                                    break;
                                case "3":
                                    Console.WriteLine("Type account number, saldo and person id seperated by comma");
                                    DataToAdd = Console.ReadLine().Split(',');
                                    BankAccountTest.BankAccountAddPersonId(connection, DataToAdd[0], DataToAdd[1], DataToAdd[2]);
                                    break;
                                case "4":
                                    Console.WriteLine("Type name, nip, regon and address id seperated by comma");
                                    DataToAdd = Console.ReadLine().Split(',');
                                    CompanyTest.CompanyAddAddressId(connection, DataToAdd[0], DataToAdd[1], DataToAdd[2], DataToAdd[3]);
                                    break;
                                case "5":
                                    Console.WriteLine("Type Name, price and description seperated by comma");
                                    DataToAdd = Console.ReadLine().Split(',');
                                    ProductTest.ProductAdd(connection, DataToAdd[0], DataToAdd[1], DataToAdd[2]);
                                    break;
                                case "6":
                                    Console.WriteLine("Type order number, date and address id  seperated by comma");
                                    DataToAdd = Console.ReadLine().Split(',');
                                    OrderTest.OrderAddAddressId(connection, DataToAdd[0], DataToAdd[1], DataToAdd[2]);
                                    break;
                                default:
                                    Console.WriteLine("Wrong option");
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Choose option:");
                            Console.WriteLine("1 - Person");
                            Console.WriteLine("2 - Address");
                            Console.WriteLine("3 - BankAccount");
                            Console.WriteLine("4 - Company");
                            Console.WriteLine("5 - Product");
                            Console.WriteLine("6 - Order");

                            string ObjectToRemove = Console.ReadLine();
                            string DataToRemove;
                            switch (ObjectToRemove)
                            {
                                case "1":
                                    Console.WriteLine("Type id of person you would like to remove");
                                    DataToRemove = Console.ReadLine();
                                    PersonTest.PersonRemove(connection, DataToRemove);
                                    break;
                                case "2":
                                    Console.WriteLine("Type id of address you would like to remove");
                                    DataToRemove = Console.ReadLine();
                                    AddressTest.AddressRemove(connection, DataToRemove);
                                    break;
                                case "3":
                                    Console.WriteLine("Type id of bank account you would like to remove");
                                    DataToRemove = Console.ReadLine();
                                    BankAccountTest.BankAccountRemove(connection, DataToRemove);
                                    break;
                                case "4":
                                    Console.WriteLine("Type id of company you would like to remove");
                                    DataToRemove = Console.ReadLine();
                                    CompanyTest.CompanyRemove(connection, DataToRemove);
                                    break;
                                case "5":
                                    Console.WriteLine("Type id of product you would like to remove");
                                    DataToRemove = Console.ReadLine();
                                    ProductTest.ProductRemove(connection, DataToRemove);
                                    break;
                                case "6":
                                    Console.WriteLine("Type id of order you would like to remove");
                                    DataToRemove = Console.ReadLine();
                                    OrderTest.OrderRemove(connection, DataToRemove);
                                    break;
                                default:
                                    Console.WriteLine("Wrong option");
                                    break;
                            }

                            break;
                        case "3":
                            Console.WriteLine("Choose option:");
                            Console.WriteLine("1 - Person");
                            Console.WriteLine("2 - Address");
                            Console.WriteLine("3 - BankAccount");
                            Console.WriteLine("4 - Company");
                            Console.WriteLine("5 - Product");
                            Console.WriteLine("6 - Order");
                            string ObjectToLog = Console.ReadLine();
                            string IdToLog;
                            switch (ObjectToLog)
                            {
                                case "1":
                                    Console.WriteLine("Type id of person you would like to log");
                                    IdToLog = Console.ReadLine();
                                    PersonTest.PersonLog(connection, IdToLog);
                                    break;
                                case "2":
                                    Console.WriteLine("Type id of address you would like to log");
                                    IdToLog = Console.ReadLine();
                                    AddressTest.AddressLog(connection, IdToLog);
                                    break;
                                case "3":
                                    Console.WriteLine("Type id of bank account you would like to log");
                                    IdToLog = Console.ReadLine();
                                    BankAccountTest.BankAccountLog(connection, IdToLog);
                                    break;
                                case "4":
                                    Console.WriteLine("Type id of company you would like to log");
                                    IdToLog = Console.ReadLine();
                                    CompanyTest.CompanyLog(connection, IdToLog);
                                    break;
                                case "5":
                                    Console.WriteLine("Type id of product you would like to log");
                                    IdToLog = Console.ReadLine();
                                    ProductTest.ProductLog(connection, IdToLog);
                                    break;
                                case "6":
                                    Console.WriteLine("Type id of order you would like to log");
                                    IdToLog = Console.ReadLine();
                                    OrderTest.OrderLog(connection, IdToLog);
                                    break;
                                default:
                                    Console.WriteLine("Wrong option");
                                    break;
                            }
                            break;
                        case "4":
                            Console.WriteLine("Choose option:");
                            Console.WriteLine("1 - Person");
                            Console.WriteLine("2 - Address");
                            Console.WriteLine("3 - BankAccount");
                            Console.WriteLine("4 - Company");
                            Console.WriteLine("5 - Product");
                            Console.WriteLine("6 - Order");
                            string TableToLog = Console.ReadLine();
                            switch (TableToLog)
                            {
                                case "1":
                                    PersonTest.PersonConsoleLog(connection);
                                    break;
                                case "2":
                                    AddressTest.AddressConsoleLog(connection);
                                    break;
                                case "3":
                                    BankAccountTest.BankAccountConsoleLog(connection);
                                    break;
                                case "4":
                                    CompanyTest.CompanyConsoleLog(connection);
                                    break;
                                case "5":
                                    ProductTest.ProductConsoleLog(connection);
                                    break;
                                case "6":
                                    OrderTest.OrderConsoleLog(connection);
                                    break;
                                default:
                                    Console.WriteLine("Wrong option");
                                    break;
                            }

                            break;
                        default:
                            Console.WriteLine("Wrong option");
                            break;
                    }

                    Console.WriteLine("====================================");
                    Console.WriteLine("Choose option - enter 'exit' to exit");
                    Console.WriteLine("====================================");
                    Console.WriteLine("1 - add object");
                    Console.WriteLine("2 - remove object");
                    Console.WriteLine("3 - get object by id");
                    Console.WriteLine("4 - get all objects");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}