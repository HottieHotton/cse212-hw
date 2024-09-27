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
        // * Scenario: Ensure maxSize equals 10 on start, add a customer and serve them
        // ? Expected Result: See the customer get returned from the queue
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Console.WriteLine(cs); // ! Output should be 10
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        cs.ServeCustomer();
        cs.ServeCustomer();

        // * Defect(s) Found: Customer was being removed from List before even becoming a variable. Changed the List to a Queue to fix the issue

        Console.WriteLine("=================");

        // Test 2
        // * Scenario: Hit max length of customer service queue
        // ? Expected Result: See error when we try to add 2 customers on a length of 1
        Console.WriteLine("Test 2");
        cs = new CustomerService(1);
        Console.WriteLine(cs); // ! Output should be 1
        cs.AddNewCustomer();
        Console.WriteLine("");
        cs.AddNewCustomer(); // ! Should throw error

        // * Defect(s) Found: The code was checking the length of the queue before even adding a new customer, which would not work until going over the limit by 1.
        // * Moved the if statement below the enqueue call and checked, if error was thrown then we would dequeue that customer.

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly Queue<Customer> _queue = new Queue<Customer>();
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
        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Enqueue(customer);
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            _queue.Dequeue();
            return;
        }
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        var customer = _queue.Dequeue();
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