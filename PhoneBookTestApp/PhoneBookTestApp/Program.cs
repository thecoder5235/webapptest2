using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace PhoneBookTestApp
{
    class Program 
    {
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                PhoneBook phonebook = new PhoneBook();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
 
                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database
 
                Person Person1 = new Person { name = "John Smith", phoneNumber = "(248) 123-4567", address = "1234 Sand Hill Dr, Royal Oak, MI" };
                Person Person2 = new Person { name = "Cynthia Smith", phoneNumber = "(824) 128-8758", address = "875 Main St, Ann Arbor, MI" };
                phonebook.addPerson(Person1);
                phonebook.addPerson(Person2);
 
 
 
 
 
                Console.WriteLine("          PhoneBook List         ");
 
                foreach(Person person in phonebook.GetPhoneBook)
                {
                    Console.WriteLine("Person Name: {0}, Phone Number:{1}, Address: {2}", person.name, person.phoneNumber, person.address);
                }
 
                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                // TODO: find Cynthia Smith and print out just her entry
                string perFirstName = "Cynthia";
                string perLastName = "Smith";
                Person findPerson = phonebook.findPerson(perFirstName, perLastName);
                Console.WriteLine("Name: " + findPerson.name);
                Console.WriteLine("Phone Number: " + findPerson.phoneNumber);
                Console.WriteLine("Address: " + findPerson.address);
 
                Console.ReadLine();
 
 
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
 
 
 
        }
    }
}
