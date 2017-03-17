using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
 
namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
 
        // add a person into  the PhoneBook
        public void addPerson(Person newPerson)
        {
            using (SQLiteConnection dbConnection = DatabaseUtil.GetConnection())
            {
                // realtime we can create a storeprocedure instead of the T-SQL
                SQLiteCommand command = new SQLiteCommand(string.Format("INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('{0}','{1}','{2 }')", newPerson.name, newPerson.phoneNumber, newPerson.address), dbConnection);
                int result = command.ExecuteNonQuery();
            }
        }
         // the findperson method will search the Phone Book Database based on the name passed as a parameter
        public Person findPerson(string firstName, string lastName)
        {
            List<Person> getPhoneBook = (List<Person>) GetPhoneBook;
            return getPhoneBook.Find(person => person.name == (firstName + " " + lastName));
        }
        // the GetPhoneBook method will retrieve all the data from the database
        public IEnumerable<Person> GetPhoneBook
        {
            get
            {
                List<Person> phonebooks = new List<Person>();
                using (SQLiteConnection dbConnection = DatabaseUtil.GetConnection())
                {
                    // this linq to sql will get name phonenumber and address from the database.
                    SQLiteCommand command = new SQLiteCommand("SELECT NAME,PHONENUMBER,ADDRESS FROM PHONEBOOK", dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Person objPer = new Person();
                        objPer.name = reader["NAME"].ToString();
                        objPer.phoneNumber = reader["PHONENUMBER"].ToString();
                        objPer.address = reader["ADDRESS"].ToString();
 
                        phonebooks.Add(objPer);
                    }
                }
                return phonebooks;
            }
 
 
 
        }
 
        }
 
    }
