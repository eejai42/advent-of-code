using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day15Tests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var data = File.ReadAllText("../../../../sample-data.txt");
            var p = new Predictor(data);
            var path = p.CalculateShortestPath();
            Console.WriteLine("Hello world");
        }
    }
}
