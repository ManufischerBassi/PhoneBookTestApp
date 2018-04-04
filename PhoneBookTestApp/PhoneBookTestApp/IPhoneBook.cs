namespace PhoneBookTestApp
{
     interface IPhoneBook
    {
        Person findPerson(string firstName, string lastName);
        bool addPerson(Person newPerson);

      }

 
}