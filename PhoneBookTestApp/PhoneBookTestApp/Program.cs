using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
               * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
               * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
               */
                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database
                string option;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("----------Phone Book Application----------");
                    //Console.WriteLine("\t Enter 'C' - for Database Confirmation");
                    Console.WriteLine("\t Enter 'C' - Create Some Dummy Person records");
                    Console.WriteLine("\t Enter 'P' - Print the Phone Book");
                    Console.WriteLine("\t Enter 'S' - Search By Name(Cynthia Smith)");
                    Console.WriteLine("\t Enter 'I' - Insert New Person in the Phone Book");
                    Console.WriteLine("\t Enter 'A' - Search By Name");
                    Console.WriteLine("\t Enter 'X' - Exit from the Application");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine(" Please Enter your choice");
                    Console.WriteLine();
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "C":
                        case "c":
                           /* TODO: create person objects and put them in the PhoneBook and database
                            * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                            * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                            */
                            create_Person_Objects_PhoneBook_Database();
                            Print_the_Phone_Book();
                            break;
                        case "P":
                        case "p":
                            // TODO: print the phone book out to System.out
                            Print_the_Phone_Book();
                            
                            break;

                        case "S":
                        case "s":
                            // TODO: find Cynthia Smith and print out just her entry
                            Console.WriteLine("-------------------------------------------");
                            Search_By_Name("Cynthia", "Smith");
                            Console.WriteLine("-------------------------------------------");
                            break;

                        case "A":
                        case "a":

                            Search_By_Any_Name();
                            break;

                        case "I":
                        case "i":
                            // TODO: insert the new person objects into the database
                            bool addNew=Insert_New_Person();
                            if (addNew == true)
                            {
                                Console.WriteLine("----> New Record Added");
                            }
                            else
                            {
                                Console.WriteLine("----> No Record Added-- Error");
                            }
                            break;
                        }

                } while (option != "X" && option != "x");
                
                Console.ReadLine();
            }
            finally
            {
               DatabaseUtil.CleanUp();
            }         

        }
         static void create_Person_Objects_PhoneBook_Database()
        {
            IPhoneBook objphonebook = new PhoneBook();
            Person _person = new Person();
            _person.name = "John Smith";
            _person.address = "1234 Sand Hill Dr, Royal Oak, MI";
            _person.phoneNumber = "(248) 123-4567";

            objphonebook.addPerson(_person);
            _person.name = "Cynthia Smith";
            _person.address = "875 Main St, Ann Arbor, MI";
            _person.phoneNumber = "(824) 128-8758";
            objphonebook.addPerson(_person);
        }

        static void Print_the_Phone_Book()
        {
            IPhoneBook objphonebook = new PhoneBook();
            Person _person = new Person();
            var listofPerson = DatabaseUtil.GetAllRows();
            Console.WriteLine("--------------------------------------------------------");
            foreach (Person item in listofPerson)
            {
                Console.WriteLine("{0}\t| {1}\t| {2}", item.name, item.phoneNumber, item.address);
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        static void Search_By_Name(string firstName, string lastName)
        {
            IPhoneBook objphonebook = new PhoneBook();
            var objfindperson = objphonebook.findPerson(firstName, lastName);
            Console.WriteLine("{0}\t| {1}\t| {2}", objfindperson.name, objfindperson.phoneNumber, objfindperson.address);

        }
        static bool Insert_New_Person()
        {
            IPhoneBook objphonebook = new PhoneBook();
            Person ojnewperson = new Person();
            Console.WriteLine("Enter Full Name: ");
            ojnewperson.name = Console.ReadLine();
            Console.WriteLine("Enter Phone No ");
            ojnewperson.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            ojnewperson.address = Console.ReadLine();
           bool rowAdded=objphonebook.addPerson(ojnewperson);
            return rowAdded;
        }
        static void Search_By_Any_Name()
        {
            IPhoneBook objphonebook = new PhoneBook();
            Console.WriteLine("Enter first Name: ");
            var _firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            var _lastName = Console.ReadLine();

            var objfindperson = objphonebook.findPerson(_firstName, _lastName);
            Console.WriteLine("{0}\t| {1}\t| {2}", objfindperson.name, objfindperson.phoneNumber, objfindperson.address);

        }
      

    }
}
