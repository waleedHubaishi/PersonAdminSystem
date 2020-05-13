using System;
namespace PersonAdminLib
{
    public class Person
    {
        private string firstname = "";

        /*public string Firstname { 
            get { return this.firstname; } 
            //value comes as default variable likewise set_Firstname(string value)           
            set { this.firstname = value; } 
        }*/

        /// in the back ground when using
        /// public string Firstname { get; set; } 
        /// it is like this
        /// 
        /// public string firstName;
        /// public string FirstName{
        /// get {return firstName;}
        /// set {firstName = value;}
        /// }
        /// 
        /// 
        /// 

        public string Firstname { get; set; }

        public string Surname { get; }

        public Person(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;

        }

        public override string ToString() {

            return firstname + " " + Surname;
        }



    }
}
