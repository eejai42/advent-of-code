
namespace TestProject2
{
    public class Tests
    {
        public Program Program { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Program = new Program();
            var op = $"{this.Program.IndexedPositions.FirstOrDefault()}";
        }

        [Test]
        public void Test1()
        {
            this.Program.Process();
        }
    }
}