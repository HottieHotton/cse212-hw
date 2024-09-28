using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    public TestContext TestContext { get; set; }
    [TestMethod]
    // * Scenario: Ensuring the highest priority returns first and the lowest last
    // ? Expected Result:"Label Failures" should be the first to return
    // ! Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var item1 = new PriorityItem("Response Times", 5);
        var item2 = new PriorityItem("Label Failures", 7);
        var item3 = new PriorityItem("Password Reset", 2);

        PriorityItem expectedResult = item2;

        var priority = new PriorityQueue();
        priority.Enqueue(item1.Value, item1.Priority);
        priority.Enqueue(item2.Value, item2.Priority);
        priority.Enqueue(item3.Value, item3.Priority);

        var ticket = priority.Dequeue();
        Assert.AreEqual(expectedResult.Value, ticket);
        TestContext.WriteLine(ticket + " - " + expectedResult.Value);
    }

    [TestMethod]
    // * Scenario: This test will confirm two instances, one with 2 of the same priority
    // * The other is checking Null Instance
    // ? Expected Result 1: Carrier Error should return as it's the closest
    // ? Expected Result 2: Error will be thrown for empty queue
    // ! Defect(s) Found: Not with the code, just with me
    public void TestPriorityQueue_2()
    {
        var priority = new PriorityQueue();

        var item1 = new PriorityItem("Response Times", 5);
        var item2 = new PriorityItem("Label Failures", 7);
        var item3 = new PriorityItem("Carrier Error", 7);
        var item4 = new PriorityItem("Password Reset", 2);

        priority.Enqueue(item1.Value, item1.Priority);
        priority.Enqueue(item2.Value, item2.Priority);
        priority.Enqueue(item3.Value, item3.Priority);
        priority.Enqueue(item4.Value, item4.Priority);

        PriorityItem expectedResult = item2;

        var ticket = priority.Dequeue();
        Assert.AreEqual(expectedResult.Value, ticket);
        TestContext.WriteLine(ticket + " - " + expectedResult.Value);

        // ! Test 2
        priority = new PriorityQueue();
        try
        {
            priority.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
            TestContext.WriteLine(e.Message);
        }
    }

}