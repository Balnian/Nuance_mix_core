using Nuance.Mix;
using System;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StreamReader creds = new StreamReader(File.OpenRead("Creds.txt"));
            Mix_Services svr = new Mix_Services(creds.ReadLine(), creds.ReadLine());
        }
    }
}