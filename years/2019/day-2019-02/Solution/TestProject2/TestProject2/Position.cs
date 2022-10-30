/*************************************************
Initially Generated by SSoT.me - 2017
    EJ Alexandra - ssotme odxml42/odxml-to-csharp-pocos
    This file WILL NOT be overwritten once changes are made.
*************************************************/
using System;
using System.ComponentModel;

namespace adventofcode.Lib.DataClasses
{

    public partial class Position
    {
        public Position(string value, int index)
        {
            this.InitPoco();
            this.Value = Int32.Parse(value);
            this.PositionIndex = index;
            this.CheckOpCode();
        }

        private void CheckOpCode()
        {
            this.IsOPCode = ((this.PositionIndex % 4) == 0) ? 1 : 0;
            if (this.IsOPCode == 1)
            {
                switch (this.Value)
                {
                    case 1:
                        this.OPCodeFunction = "ADD";
                        break;

                    case 2:
                        this.OPCodeFunction = "MULTIPLY";
                        break;

                    case 99:
                        this.OPCodeFunction = "HALT";
                        break;
                }
            }
        }

        public override String ToString()
        {
            return $"Position: {this.PositionIndex}={this.Value}{(this.IsOPCode == 1 ? $"({this.OPCodeFunction})" : "")}";
        }

    }
}