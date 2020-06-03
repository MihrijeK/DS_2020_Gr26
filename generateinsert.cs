using System;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;



namespace ds
{
    public class generateinsert
    {
        Connection C = new Connection();
        public static void GjenerimiPdheInsertimi(string name)
        {
            {

                DatabaseConnection DB = new DatabaseConnection();
                string pass = "";
                string pass1 = "";
                Console.Write("Enter password:");
