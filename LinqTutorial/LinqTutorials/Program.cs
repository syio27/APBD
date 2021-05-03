using LinqTutorials.Models;
using System;
using System.Collections;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = (IEnumerable)LinqTasks.Task1();
            foreach (var v in t1)
            {
                Console.WriteLine(v);
            }

            var t2 = (IEnumerable)LinqTasks.Task2();
            foreach (var v in t2)
            {
                Console.WriteLine(v);
            }

            var t3 = LinqTasks.Task3();
            Console.WriteLine(t3);

            var t4 = (IEnumerable)LinqTasks.Task4();
            foreach (var v in t4)
            {
                Console.WriteLine(v);
            }

            var t5 = (IEnumerable)LinqTasks.Task5();
            foreach (var v in t5)
            {
                Console.WriteLine(v);
            }

            var t6 = (IEnumerable)LinqTasks.Task6();
            foreach (var v in t6)
            {
                Console.WriteLine(v);
            }

            var t7 = (IEnumerable)LinqTasks.Task7();
            foreach (var v in t7)
            {
                Console.WriteLine(v);
            }

            var t8 = LinqTasks.Task8();
            Console.WriteLine(t8);

            var t9 = LinqTasks.Task9();
            Console.WriteLine(t9);

            var t10 = (IEnumerable)LinqTasks.Task10();
            foreach (var v in t10)
            {
                Console.WriteLine(v);
            }

            var t14 = (IEnumerable)LinqTasks.Task14();
            foreach (var v in t14)
            {
                Console.WriteLine(v);
            }
        }
    }
}
