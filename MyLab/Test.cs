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
            var list = new List<string>();
            for (int i = 0; i < 10_000; i++)
     
            {
                var record = Payments[i].Split(',');
                if (list.Contains(record[2])==false)
                {
                    list.Add(record[2]);
                }
            }

            Console.WriteLine($"count: {list.Count}");
        }

        [Benchmark]
        public void Case2()
        {
            var hashset = new HashSet<string>(Users);
            //for (int i = 0; i < 10_000; i++)
            //{
            //    var record = Payments[i].Split(',');
            //    if (hashset.Contains(record[2]) == false)
            //    {
            //        hashset.Add(record[2]);
            //    }
            //}
            
            Console.WriteLine($"count: {hashset.Count}");
        }
    }
}
