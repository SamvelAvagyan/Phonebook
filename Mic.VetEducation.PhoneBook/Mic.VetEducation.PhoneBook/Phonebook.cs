using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mic.VetEducation.PhoneBook
{
    class Phonebook : IEnumerable, ICloneable
    {
        public string name;
        public int number;
        public int Count { get; set; }
        Phonebook _last;
        public Phonebook Next;

        public void Add(string name, int number)
        {
            if (Count == 0)
            {
                this.name = name;
                this.number = number;
                Count++;
                _last = this;
            }
            else
            {
                _last.Next = new Phonebook { name = name, number = number };
                _last = _last.Next;
                Count++;
            }
        }

        public void Insert(ref Phonebook pb, int index, string name, int number)
        {
            int i = 0;

            foreach (Phonebook item in pb)
            {
                if (i == index)
                {
                    item.name = name;
                    item.number = number;

                    return;
                }

                i++;
            }
        }

        public void RemoveAt(ref Phonebook pb, int index)
        {
            int i = 0;
            Phonebook _root = (Phonebook)pb.Clone();

            foreach (Phonebook person in _root)
            {
                if(i == index)
                {
                    pb = person.Next;
                    return;
                }

                pb = pb.Next;

                i++;
            }
        }

        public Phonebook this[string key, int v]
        {
            get
            {
                foreach(Phonebook person in this)
                {
                    if(person.name == key && person.number == v)
                    {
                        return person;
                    }
                }

                return null;
            }

            set
            {
                foreach (Phonebook person in this)
                {
                    if (person.name == key && person.number == v)
                    {
                        person.name = key;
                        person.number = v;
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.name;
        }



        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public object Clone()
        {
            return new Phonebook { name = this.name, number = this.number, Next = this.Next, _last = this._last };
        }

        class Enumerator : IEnumerator
        {
            public Phonebook pb;
            public object Current { get; private set; }

            public Enumerator(Phonebook pb)
            {
                this.pb = pb;
            }

            public bool MoveNext()
            {
                if (pb == null)
                    return false;

                Current = new Phonebook { name = pb.name, number = pb.number };
                pb = pb.Next;
                return true;
            }

            public void Reset()
            {
                pb.Next = null;
            }
        }
    }
}
