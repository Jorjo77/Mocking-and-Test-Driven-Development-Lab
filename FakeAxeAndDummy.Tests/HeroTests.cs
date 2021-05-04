using FakeAxeAndDummy;
using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    //private FakeAxe wepone;
    //private FakeDummy target;

    //[SetUp]
    //public void TestFixtureSetup()
    //{
    //    wepone = new FakeAxe();
    //    target = new FakeDummy();
    //}


    [Test]
    public void HeroShouldGainsExperienceWhenTargetDies()
    {
        Mock<IWeapon> mockedAxe = new Mock<IWeapon>();
        Mock<ITarget> mockedDummy = new Mock<ITarget>();
        mockedDummy.Setup(x => x.GiveExperience()).Returns(10);
        mockedDummy.Setup(x => x.IsDead()).Returns(true);


        Hero hero = new Hero("A", mockedAxe.Object);
        hero.Attack(mockedDummy.Object);

        var expectedResult = 10;
        var actualResult = hero.Experience;

        Assert.AreEqual(expectedResult, actualResult);
    }
}