using System;
using System.Collections.Generic;
using System.IO;

namespace PersonAdminLib
{

    public delegate void PersonAddedHandler(object source, PersonEventArgs args);

    public class PersonRegister
    {
        public event PersonAddedHandler PersonEventHandler;

        public List<Person> Persons { get { return this.personList; } }

        private List<Person> personList = new List<Person>();

        public int Count {
            get { return personList.Count; }
        }

        public PersonRegister()
        {
            Add(new Person("Waleed","Al-Hubaishi"));
            Add(new Person("Wing", "Kha"));
            Add(new Person("Julien", "Christen"));
            //ReadPersonsFromFile("Persons.txt");

        }

        public Person this[int index] {

            get { return personList[index]; }
            set { personList[index] = value; }
        }

        public int ReadPersonsFromFile(string filename) {
            int counter = 0;

            using (var reader = new StreamReader(filename)) {
                string personString;

                while ((personString = reader.ReadLine()) != null) {

                    string[] name = personString.Split("\t");
                    Add(new Person(name[0], name[1]));
                    counter++;
                }

            }
            return counter; 
        }

        public void PrintPersons() {

            foreach(var p in Persons ){

            Console.WriteLine($"{p.Surname} {p.Firstname}");
            }
        }

        public void Sort(Comparison<Person> c) {

            personList.Sort(c);
        }

        public int Add(Person newPerson) {

            personList.Add(newPerson);
            PersonEventHandler?.Invoke(this, new PersonEventArgs(newPerson));
            return personList.Count;
        }

        public Person FindPerson(string surename)
         {
            foreach (var p in personList)
                if (p.Surname == surename.Trim())
                    return p;

            return null; 
        }



        public IEnumerable<string> GetPersons()
        {
            return personList.GetItemsAsString();
        }
    }

    
}
