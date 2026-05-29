using System;

namespace DesignPatternsCollection.Observer
{
    public static class ObserverDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 2: OBSERVER — Order Notifications                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            var order = new Order("ORD-20260525-001");

            var emailService     = new EmailService();
            var smsService       = new SmsService();
            var inventoryService = new InventoryService();

            order.Subscribe(emailService);
            order.Subscribe(smsService);
            order.Subscribe(inventoryService);

            order.SetStatus("Processing");
            order.SetStatus("Shipped");

            Console.WriteLine();
            order.Unsubscribe(smsService);

            order.SetStatus("Delivered");

            Console.WriteLine();
        }
    }
}
