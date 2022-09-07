namespace AppForTest;
using AppForTest;
[TestFixture]
public class ImplementationTest
{
    private Implementation implementation;
    [SetUp]
    public void Setup()
    {
        implementation = new Implementation();
    }

    [Test]
    public void AddTest()
    {
        // 1. Arrange
        int x = 100;
        int y = 300;
        int Expected = 400;
        // 2. Act
        int Actual = implementation.Add(x,y);

        // 3. Assertion

        Assert.AreEqual(Expected,Actual);
    }

    [Test]
    public void CheckValueTrueTest()
    {
        int x = 9;
        var actual = implementation.CheckValue(x);
        // Boolean Check
        Assert.IsTrue(actual);
    }

    [Test]
    public void CheckValueFalseTest()
    {
        int x = -9;
        var actual = implementation.CheckValue(x);
        // Boolean Check
        Assert.IsFalse(actual);
    }

    [Test]
    public void LoginTest()
    {
        string uname = "Mahesh1";
        string pwd = "123";
        var actual = implementation.Login(uname,pwd);
        Assert.IsTrue(actual);
    }

    [TestCase("Mahesh1","123")]
    [TestCase("Mahesh2", "123")]
    [TestCase("Mahesh3", "123")]
    [TestCase("Mahesh4", "123")]
    public void LoginTestWithData(string uname, string pwd)
    {
        var actual = implementation.Login(uname,pwd);
        Assert.IsTrue(actual);
    }

    [Test]
    public void ProcessExceptionTest()
    {

Assert.Throws<Exception>(()=>implementation.ProcessData(88));
    }
}
