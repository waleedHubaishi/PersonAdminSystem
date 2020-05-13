using System;
using System.Reflection;

//first Dependencies then Edit refrences then all then add the library or select it
using PersonAdminLib;

namespace PersonAdmin
{
    //Documentaion Comment
    /// <summary>
    /// Person admin application.
    /// </summary>
    class PersonAdminApplication
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My first C# Program {0}", Assembly.GetExecutingAssembly().GetName().Version);
            //Console.WriteLine("Press any key to quit");
            //Console.ReadKey();

            /// you cant change the type of the variable var later on. 
            var person = new Person("James","Mason");

           
            person.Firstname = "Mason";
            Console.WriteLine("Person: {0} {1}",person.Firstname,person.Surname);


            var personRegister = new PersonRegister();

            personRegister.PersonEventHandler += WriteNewPersonToConsole;

            Console.WriteLine($"Person: {personRegister[personRegister.Count -1].Firstname} {personRegister[personRegister.Count-1].Surname}");
            Console.WriteLine(personRegister.ReadPersonsFromFile("Persons.txt"));

            personRegister.Sort(SortBySurename);


            Comparison<Person> comp = NoCompare;
            personRegister.Sort(comp);
            for (int i=0;i<personRegister.Count;i++) {
                Console.WriteLine($"{personRegister[i].Firstname} {personRegister[i].Surname}"); 
            }
        }

        static void WriteNewPersonToConsole(object source, PersonEventArgs personEventArgs) {

            Console.WriteLine($"Newly added person: {personEventArgs.NewPerson.Firstname} {personEventArgs.NewPerson.Surname}"); 
        }

        static int SortBySurename(Person p1, Person p2) {

            return string.Compare(p1.Surname, p2.Surname, StringComparison.CurrentCulture); 
        }

        static int NoCompare(Person p1, Person p2)
        {

            return -1;
        }


    }
}
