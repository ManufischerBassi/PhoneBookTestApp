﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void initializeDatabase()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();
            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "drop table PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static List<Person> GetAllRows()
        {
            List<Person> listofPerson = new List<Person>();
            var dbConnection = GetConnection();
            string query = "select * from PHONEBOOK";
            SQLiteCommand myCommand = new SQLiteCommand(query, dbConnection);
           SQLiteDataReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Person objPerson = new Person();
                    objPerson.name = result["NAME"].ToString();
                    objPerson.phoneNumber = result["PHONENUMBER"].ToString();
                    objPerson.address = result["ADDRESS"].ToString();
                    listofPerson.Add(objPerson);
                }
            }
            dbConnection.Close();
            return listofPerson;
        }

    }
}