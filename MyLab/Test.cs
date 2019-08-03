using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLab
{
    public class Test
    {
        [Benchmark]
        public void Case1()
        {
            var list = new List<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i);
            }
        }        

        [Benchmark]
        public void Case2()
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.AddLast(i);
            }
        }

        [Benchmark]
        public void Case3()
        {
            var list = new int[1_000_000];
            for (int i = 0; i < 1_000_000; i++)
            {
                list[i] = i;
            }
        }
    }
}
