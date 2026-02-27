namespace Mutual_Friends_Network
{
    class Person
    {
        public string Name { get; set; }
        public List<Person> Friends = new List<Person>();

        public Person(string name) => Name = name;

        //public void AddFriend(Person friend)
        //{
        //    if (!Friends.Contains(friend))
        //    {
        //        Friends.Add(friend);
        //        friend.Friends.Add(this);
        //    }
        //}
    }

    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();

        public void AddMember(Person member)
        {
            if (!_members.Contains(member))
            {
                _members.Add(member);
            }
        }

        //public void Show()
        //{
        //    foreach (var member in _members)
        //    {
        //        Console.WriteLine(member.Name);
        //    }

        //}

        //public bool IsMember(Person person)
        //{
        //    return _members.Contains(person);
        //}


        public void AddFriend(Person p1, Person p2)
        {
            if (!(_members.Contains(p1)) && (_members.Contains(p2)))
            {
                Console.WriteLine("Both persons must be members of the network.");
                return;
            }

            if (!p1.Friends.Contains(p2))
            {
                p1.Friends.Add(p2);
                p2.Friends.Add(p1);
            }
        }


        public void ShowNetwork()
        {
            foreach (var member in _members)
            {
                Console.Write(member.Name + "->");
                List<string> friends = new List<string>();

                foreach (var friend in member.Friends)
                {
                    friends.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(",", friends)}");

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            Person aman = new Person("Aman");
            Person bhaskar = new Person("Bhaskar");
            Person chetan = new Person("Chetan");
            Person divakar = new Person("Divakar");

            network.AddMember(aman);
            network.AddMember(bhaskar);
            network.AddMember(chetan);
            //network.AddMember(divakar);


            network.AddFriend(aman, bhaskar);
            network.AddFriend(bhaskar, chetan);
            network.AddFriend(chetan, divakar);
            //network.AddFriend(divakar);


            //aman.AddFriend(bhaskar);
            //aman.AddFriend(chetan);
            //bhaskar.AddFriend(divakar);
            //chetan.AddFriend(divakar);


            network.ShowNetwork();
        }
    }
}
