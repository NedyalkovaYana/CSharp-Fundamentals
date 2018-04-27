using System;

namespace _02.ExtendedDatabase
{
    public class People : IPeople
    {
        public People(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; }
        public string Username { get; }
    }
}
