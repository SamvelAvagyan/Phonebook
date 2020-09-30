using System;
using System.Collections.Generic;

namespace Mic.VetEducation.PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new Phonebook();
            pb.Add("A1", 1);
            pb.Add("A2", 2);
            pb.Add("A3", 3);
            pb.Add("A4", 4);
            pb.Add("A5", 5);

            foreach(Phonebook person in pb)
            {
                Console.Write(person.name + ", ");
                Console.WriteLine(person.number);
            }

            //pb.RemoveAt(ref pb, 2);

            foreach (Phonebook person in pb)
            {
                Console.Write(person.name + ", ");
                Console.WriteLine(person.number);
            }

            Console.WriteLine("=====================");

            Console.WriteLine(pb["A2", 2]);
        }
    }
}
