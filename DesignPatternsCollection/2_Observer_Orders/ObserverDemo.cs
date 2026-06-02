using System;

namespace DesignPatternsCollection.Observer
{
    // Demo — subscribes observers, triggers status changes, and shows unsubscribe.
    public static class ObserverDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 2: OBSERVER — Order Notifications                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            var order = new Order("ORD-20260525-001");

            // Create and subscribe all three observer services.
            var emailService     = new EmailService();
            var smsService       = new SmsService();
            var inventoryService = new InventoryService();

            order.Subscribe(emailService);
            order.Subscribe(smsService);
            order.Subscribe(inventoryService);

            // Trigger status changes — all observers get notified.
            order.SetStatus("Processing");
            order.SetStatus("Shipped");

            // Unsubscribe SMS — only Email and Inventory receive the next update.
            Console.WriteLine();
            order.Unsubscribe(smsService);

            order.SetStatus("Delivered");

            Console.WriteLine();
        }
    }
}
