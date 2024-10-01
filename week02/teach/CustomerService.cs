using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // The user shall specify the maximum size of the Customer Service Queue when it is created. If the size is invalid (less than or equal to 0) then the size shall default to 10.
        // Scenario: if less than zero, size is 10 
        // Expected Result: if less than zero, size is 10
        Console.WriteLine("Test 1");
        Assert.AreEqual(10, new CustomerService(-1)._maxSize);
        Assert.AreEqual(10, new CustomerService(0)._maxSize);
        var number = new Random().Next(1, int.MaxValue);
        Assert.AreEqual(number, new CustomerService(number)._maxSize);

        // Defect(s) Found: no defects

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The AddNewCustomer method shall enqueue a new customer into the queue.  
        // Expected Result: After adding a new customer, it should be in the queue 
        Console.WriteLine("Test 2");

        var cs = new CustomerService(1);
        cs.AddNewCustomer();
        Assert.AreEqual(1, cs._queue.Count);
        cs.AddNewCustomer();
        Assert.AreEqual(2, cs._queue.Count);

        // Defect(s) Found: enters two customers instead of one

        Console.WriteLine("=================");

        // Test 3
        // Scenario: If the queue is full when trying to add a customer, then an error message will be displayed.
        // Expected: Error when queue is full
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        cs._queue.Add(new Customer("name", "account id", "problem"));
        Assert.ThrowsException<InvalidOperationException>(() => cs.AddNewCustomer());

        // Defect(s) Found: Does not throw an error when full
        
        // Test 4
        // Scenario: The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected: 
        Console.WriteLine("Test 4");
        
        // Defect(s) Found:
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}