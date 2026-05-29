using System;

namespace DesignPatternsCollection.Observer
{
    public class EmailService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📧 EmailService: Sending email — " +
                              $"\"Your order [{orderId}] is now '{newStatus}'.\"");
        }
    }

    public class SmsService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📱 SmsService: Sending SMS — " +
                              $"\"Order [{orderId}] update: {newStatus}.\"");
        }
    }

    public class InventoryService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📦 InventoryService: Logging status '{newStatus}' " +
                              $"for order [{orderId}] in the database.");
        }
    }
}
