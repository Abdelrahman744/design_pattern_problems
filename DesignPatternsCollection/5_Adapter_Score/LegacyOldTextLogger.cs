using System;

namespace DesignPatternsCollection.Adapter
{
    // Adaptee — incompatible third-party class we cannot modify.
    public class LegacyOldTextLogger
    {
        public void WriteLogEntry(string date, string text)
        {
            Console.WriteLine($"    [LEGACY LOGGER] Date: {date} | Entry: \"{text}\"");
        }
    }
}
