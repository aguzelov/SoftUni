namespace Database
{
    public class Person
    {
        private long id;
        private string username;

        public Person(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public long Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }

        private bool Equals(Person person)
        {
            bool isEqual =
                this.Id == person.Id &&
                this.Username == person.Username;

            return isEqual;
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (person == null) return false;

            return this.Equals(person);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}