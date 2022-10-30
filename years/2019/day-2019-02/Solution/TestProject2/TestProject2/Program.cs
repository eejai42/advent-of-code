using adventofcode.Lib.DataClasses;

namespace TestProject2
{
    public class Program
    {
        public Program(string data)
        {
            var positionValues = data.Split(",".ToCharArray());
            this.IndexedPositions = new List<Position>();
            for (int i = 0; i < positionValues.Length; i++)
            {
                var newPosition = new Position(positionValues[i], i);
                this.IndexedPositions.Add(newPosition);
            }
        }

        public List<Position> IndexedPositions { get; }


        public int CurrentIndex { get; set; }
        public Position Current { get { return this.IndexedPositions[this.CurrentIndex]; } }
        public Position Value1 { get { return this.IndexedPositions[this.CurrentIndex + 1]; } }
        public Position Value2 { get { return this.IndexedPositions[this.CurrentIndex + 2]; } }
        public Position Target { get { return this.IndexedPositions[this.CurrentIndex + 3]; } }

        public int Result { get; private set; }

        internal void Process()
        {
            this.CurrentIndex = 0;
            while (this.Current.OPCodeFunction != "HALT")
            {
                Console.WriteLine(this.Current);

                var value1 = this.ReadValue(this.Value1);
                var value2 = this.ReadValue(this.Value2);
                var result = this.OperateOn(value1, value2);
                this.WriteValue(this.Target, result);
                this.CurrentIndex += 4;
            }
            this.Result = this.IndexedPositions[0].Value.Value;
        }

        private void WriteValue(Position target, int result)
        {
            Console.WriteLine($"Writing value {result} to index {target.PositionIndex}");
            this.IndexedPositions[target.Value.Value].Value = result;
        }

        private int OperateOn(int value1, int value2)
        {
            if (this.Current.OPCodeFunction == "ADD") return value1 + value2;
            else if (this.Current.OPCodeFunction == "MULTIPLY") return value1 * value2;
            else throw new Exception("Unexpected function");
        }

        private int ReadValue(Position position)
        {
            var value = this.IndexedPositions[position.Value.Value].Value.Value;
            Console.WriteLine($"Reading value {value} from {position.PositionIndex}");
            return value;
        }
    }
}