﻿using BenchmarkDotNet.Running;
using System;

namespace MyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BenchmarkRunner.Run<Test>();
        }
    }
}
