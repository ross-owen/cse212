using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

namespace code;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Expected Result: After adding to the queue, that item should be the last item in the queue. (at index zero)
    // Defect(s) Found: enqueue is not adding to index zero, but adding to the top of the queue 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("one", 1);
        priorityQueue.Enqueue("two", 2);
        priorityQueue.Enqueue("three", 3);

        Assert.AreEqual("[three (Pri:3), two (Pri:2), one (Pri:1)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
    // Expected Result: dequeue should find element 3 with highest priority
    // Defect(s) Found: it returns the correct item, but does not dequeue it
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("one", 1);
        priorityQueue.Enqueue("three", 3);
        priorityQueue.Enqueue("two", 2);

        Assert.AreEqual("three", priorityQueue.Dequeue());
        Assert.AreEqual("two", priorityQueue.Dequeue());
        Assert.AreEqual("one", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Expected Result: more than one item with the same priority should be FIFO
    // Defect(s) Found: no defects
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("one", 1);
        priorityQueue.Enqueue("two 1", 2);
        priorityQueue.Enqueue("three 1", 3);
        priorityQueue.Enqueue("three 2", 3);
        priorityQueue.Enqueue("two 2", 2);
        priorityQueue.Enqueue("three 3", 3);

        Assert.AreEqual("three 1", priorityQueue.Dequeue());
        Assert.AreEqual("three 2", priorityQueue.Dequeue());
        Assert.AreEqual("three 3", priorityQueue.Dequeue());
        Assert.AreEqual("two 1", priorityQueue.Dequeue());
        Assert.AreEqual("two 2", priorityQueue.Dequeue());
        Assert.AreEqual("one", priorityQueue.Dequeue());
    }
    
    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown.
    // Expected Result: Exception
    // Defect(s) Found: No defects
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        
        priorityQueue.Enqueue("one", 1);
        priorityQueue.Enqueue("two", 2);
        priorityQueue.Enqueue("three", 3);

        priorityQueue.Dequeue();
        priorityQueue.Dequeue();
        priorityQueue.Dequeue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}