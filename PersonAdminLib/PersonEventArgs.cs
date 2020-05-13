namespace PersonAdminLib
{
    public class PersonEventArgs
    {
        public Person NewPerson { get; }

        public PersonEventArgs(Person person) {
            NewPerson = person;
        }




    }
}