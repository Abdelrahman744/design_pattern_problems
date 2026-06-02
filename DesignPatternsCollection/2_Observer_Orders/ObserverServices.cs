using System;

// Concrete Observers — each service reacts differently to order updates.
namespace DesignPatternsCollection.Observer
{
    // Sends an email notification when the order status changes.
    public class EmailService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📧 EmailService: Sending email — " +
                              $"\"Your order [{orderId}] is now '{newStatus}'.\"");
        }
    }

    // Sends an SMS notification when the order status changes.
    public class SmsService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📱 SmsService: Sending SMS — " +
                              $"\"Order [{orderId}] update: {newStatus}.\"");
        }
    }

    // Logs the status change in the inventory database.
    public class InventoryService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📦 InventoryService: Logging status '{newStatus}' " +
                              $"for order [{orderId}] in the database.");
        }
    }
}
