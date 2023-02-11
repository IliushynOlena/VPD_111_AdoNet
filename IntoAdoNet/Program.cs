﻿using System;
using System.Data.SqlClient;
using System.Text;

namespace IntoAdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;Initial Catalog=SportShop;
                                    Integrated Security=True;Connect Timeout=2;";

            SqlConnection sqlconnection = new SqlConnection(connectionString);
            sqlconnection.Open();
            Console.WriteLine("Connection sucessfully");

            #region ExecuteNonQuery - виконує команду яка не
            //string cmdText = @"INSERT INTO Products
            //                   VALUES ('Shtanga', 'Equipment', 4, 3550, 'Ukraine', 3000)";

            //SqlCommand command = new SqlCommand(cmdText, sqlconnection);
            //command.CommandTimeout = 5; // default - 30sec


            //// ExecuteNonQuery - виконує команду яка не повертає результат (insert, update, delete...),
            ////                   але метод повертає кількітсь рядків, які були задіяні
            //int rows = command.ExecuteNonQuery();

            //Console.WriteLine(rows + " rows affected!");
            #endregion

            #region Execute Scalar
            //string cmdText = @"select AVG(Price) from Products";

            //SqlCommand command = new SqlCommand(cmdText, sqlconnection);

            //// Execute Scalar - виконує команду, яка повертає одне значення
            //int res = (int)command.ExecuteScalar();

            //Console.WriteLine("Result: " + res);
            #endregion



            #region Execute Reader
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, sqlconnection);

            // ExecuteReader - виконує команду select та повертає результат у вигляді DbDataReader
            SqlDataReader reader = command.ExecuteReader();

           

            Console.OutputEncoding = Encoding.UTF8;

            // відображається назви всіх колонок таблиці
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader.GetName(i) + "\t");
            }
            Console.WriteLine("\n-------------------------------------------------------------------------------------");

            // відображаємо всі значення кожного рядка
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }

            reader.Close();
            #endregion

            sqlconnection.Close();


        }
    }
}
