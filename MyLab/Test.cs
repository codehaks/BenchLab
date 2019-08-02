using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLab
{
    public class Test
    {
        public string _path = @"D:\Projects\Data\pin-payments.csv";
        public string[] Payments { get; set; }
        public string[] Users { get; set; }

        public Test()
        {
            Payments = System.IO.File.ReadAllLines(_path).Take(10_000).ToArray();
            Users = new string[Payments.Length];

            for (int i = 0; i < Payments.Length; i++)
            {
                var record = Payments[i].Split(',');
                Users[i] = record[2];
            }
        }

        [Benchmark]
        public void Case1()
        {
            var linkedList = new LinkedList<int>();

            for (int i = 0; i < Payments.Length; i++)
            {
                var record = Payments[i].Split(',');
                var value = int.Parse(record[4]) - int.Parse(record[3]);
                
                linkedList.AddLast(value);
            }

            Console.WriteLine($"Count : {linkedList.Sum()}");
        }

        [Benchmark]
        public void Case2()
        {
            var list = new List<int>();

            for (int i = 0; i < Payments.Length; i++)
            {
                var record = Payments[i].Split(',');

                var value = int.Parse(record[4]) - int.Parse(record[3]);
                list.Add(value);
            }

            Console.WriteLine($"Count : {list.Sum()}");
        }
    }
}
