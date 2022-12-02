using System;

namespace TestProject4
{
    internal class StrategyGuide
    {
        private string RawData;

        public StrategyGuide(string data)
        {
            this.RawData = data;
        }

        internal int GetTotal()
        {
            return -1;   
        }
    }
}