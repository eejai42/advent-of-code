namespace Day12Tests
{
    public class Tunnel
    {
        public Cave LeftCave { get; internal set; }
        public Cave RightCave { get; internal set; }


        public override string ToString()
        {
            return $"{this.LeftCave}<->{this.RightCave}";
        }
    }
}