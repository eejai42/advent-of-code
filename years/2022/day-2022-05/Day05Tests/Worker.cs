using System;
using System.IO;

namespace Day05Tests
{
    internal class Worker
    {
        public string Data { get; private set; }

        public Worker()
        {
        }

        internal void LoadData(string path)
        {
            this.Data = File.ReadAllText(path);
        }

        internal int GetAnswerWork()
        {
            return 42;
        }

        internal int GetAnswerWork2()
        {
            return 42;
        }
    }
}