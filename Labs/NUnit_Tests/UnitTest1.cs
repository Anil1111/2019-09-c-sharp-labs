using NUnit.Framework;
using lab_13_test_me_out;
using lab_12_rabbit_explosion_3age;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMeSomething_RunThisTestNow()
        {
            var expected = 100;
            var actual = TestMeSomething.RunThisTestNow(10);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 100)]
        [TestCase(100, 10000)]
        [TestCase(9, 81)]
        public void TestMeSomething_RunThisTestNow_Tests(int input, int expected)
        {
            var actual = TestMeSomething.RunThisTestNow(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000, 20)]
        [TestCase(100, 14)]
        public void TestRabbitExplosion(int populationLimit, int expectedYears)
        {
            //arrange

            //act
            var actualYears = lab_just_do_it_rabbit_explosion.Rabbit_Exponentional_Growth(populationLimit);
            Assert.AreEqual(expectedYears, actualYears.years);
            //
        }
    }
}