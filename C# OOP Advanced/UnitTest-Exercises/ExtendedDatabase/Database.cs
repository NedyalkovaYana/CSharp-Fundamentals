using System;
using System.Collections.Generic;
using System.Linq;
using _02.ExtendedDatabase;

namespace _01.DataBaseT
{
    public class Database
    {
        private HashSet<IPeople> people;


        public Database()
        {
            this.people = new HashSet<IPeople>();
        }

        public Database(IEnumerable<IPeople> people)
            :this()
        {
            if (people != null)
            {
                foreach (var person in people)
                {
                    this.Add(person);
                }
            }
        }

        public int Count => this.people.Count;

        public void Add(IPeople person)
        {
            if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove(IPeople person)
        {
            this.people.Remove(person);
        }


        public IPeople FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            var findedPerson = this.people.FirstOrDefault(p => p.Username == username);

            if (findedPerson == null)
            {
                throw new InvalidOperationException();
            }

            return findedPerson;
        }

        public IPeople FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var findedPersonById = this.people.FirstOrDefault(p => p.Id == id);

            if (findedPersonById == null)
            {
                throw new InvalidOperationException();
            }

            return findedPersonById;
        }
    }
}
