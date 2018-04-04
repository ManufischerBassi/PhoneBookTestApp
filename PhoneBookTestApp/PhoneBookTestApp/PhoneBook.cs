using System;
using System.Data.SQLite;
using PhoneBookTestAppTests;
namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        Person IPhoneBook.findPerson(string firstName, string lastName)
        {
            Person objPerson = new Person();
            var dbconnection = DatabaseUtil.GetConnection();
            string query = "select * from PHONEBOOK  where NAME=@name";
            SQLiteCommand myCommand = new SQLiteCommand(query, dbconnection);
            myCommand.Parameters.AddWithValue("@NAME", firstName + " " + lastName);
            SQLiteDataReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {              
                while (result.Read())
                {
                    objPerson.name = result["NAME"].ToString();
                    objPerson.phoneNumber = result["PHONENUMBER"].ToString();
                    objPerson.address = result["ADDRESS"].ToString();
                }
            }
           return objPerson;
        }

        bool IPhoneBook.addPerson(Person newPerson)
        {
            var dbconnection = DatabaseUtil.GetConnection();
            int result = 0;
            bool rowAdded;
            string query = "INSERT INTO PHONEBOOK ('NAME','PHONENUMBER', 'ADDRESS') VALUES (@NAME,@PHONENUMBER, @ADDRESS)";
            SQLiteCommand myCommand = new SQLiteCommand(query, dbconnection);
            myCommand.Parameters.AddWithValue("@NAME", newPerson.name);
            myCommand.Parameters.AddWithValue("@PHONENUMBER", newPerson.phoneNumber);
            myCommand.Parameters.AddWithValue("@ADDRESS", newPerson.address);
            result = myCommand.ExecuteNonQuery();
            dbconnection.Close();
            if (result > 0)
            {
                rowAdded = true;
            }else
            {
                rowAdded = false;
            }
            return rowAdded;
        }

       
    }
}