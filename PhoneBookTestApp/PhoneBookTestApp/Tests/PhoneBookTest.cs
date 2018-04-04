using NUnit.Framework;
using PhoneBookTestApp;
using System.Collections.Generic;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class PhoneBookTest
    {
        [Test]
        public void addPerson()
        {
            //Arrange
              Person p = new Person();
                p.name = "Cynthia Smith";
                p.address = "875 Main St, Ann Arbor, MI";
                p.phoneNumber = "(824) 128-8758";
            //Act
            IPhoneBook objphonebook = new PhoneBook();
            bool inserted= objphonebook.addPerson(p);
            //Assert
            Assert.IsTrue(inserted);
            //  Assert.Fail();
        }

        [Test]
        public void findPerson()
        {
             //Arrange
            string firstName = "Cynthia";
            string lastName="Smith";
            string fullName = firstName + " " + lastName;
            //Act
            IPhoneBook objphonebook = new PhoneBook();
            var objfindperson = objphonebook.findPerson(firstName, lastName);
            //Assert
                Assert.AreEqual(objfindperson.name, fullName);
        //    Assert.Fail();
        }

        [Test]
        public void getPhoneBook()
        {
            //Arrange
            IPhoneBook objphonebook = new PhoneBook();
            List<Person> listofPerson = new List<Person>();
            
            //Act
            listofPerson = DatabaseUtil.GetAllRows();

            //Assert
            int total_rows = listofPerson.Count;
            Assert.IsTrue( total_rows>0);
        }


    }

    // ReSharper restore InconsistentNaming 
}