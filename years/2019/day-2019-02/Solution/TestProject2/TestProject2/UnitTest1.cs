
namespace TestProject2
{
    public class Tests
    {
        public string TestData { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.TestData = File.ReadAllText("../../../TestData.txt");
        }

        [Test]
        public void Test1()
        {
            var test1 = "1,0,0,0,99";
            var program = new Program(test1);
            program.Process();

            Assert.That(program.Result, Is.EqualTo(2));
        }

        [Test]
        public void Test2()
        {
            var test1 = "2,3,0,3,99";
            var program = new Program(test1);
            program.Process();

            Assert.That(program.IndexedPositions[3].Value.Value, Is.EqualTo(6));
        }

        [Test]
        public void Test5()
        {
            var program = new Program(this.TestData);

            program.IndexedPositions[1].Value = 12;
            program.IndexedPositions[2].Value = 2;
            program.Process();

            Assert.That(program.Result, Is.EqualTo(4945026));
        }
    }
}