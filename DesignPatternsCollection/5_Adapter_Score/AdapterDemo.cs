using System;

namespace DesignPatternsCollection.Adapter
{
    public static class AdapterDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 5: ADAPTER — Legacy Score Saver                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Step 1: Show the legacy logger's incompatible interface.
            Console.WriteLine("  ▸ STEP 1: The legacy logger uses (date, text) — not SaveWin(player).");
            Console.WriteLine();

            var legacyLogger = new LegacyOldTextLogger();
            Console.WriteLine("    Calling legacy logger directly:");
            legacyLogger.WriteLogEntry("2025-01-15 10:30:00", "Manual log entry");
            Console.WriteLine();

            // Step 2: Use the Adapter to bridge the gap.
            Console.WriteLine("  ▸ STEP 2: ScoreAdapter bridges IScoreSaver → LegacyOldTextLogger.");
            Console.WriteLine();

            IScoreSaver scoreSaver = new ScoreAdapter(legacyLogger);

            Console.WriteLine("    Saving wins through IScoreSaver:");
            scoreSaver.SaveWin("Alice");
            scoreSaver.SaveWin("Bob");
            scoreSaver.SaveWin("Charlie");
            Console.WriteLine();

            // Step 3: Prove client code only depends on IScoreSaver.
            Console.WriteLine("  ▸ STEP 3: Game method uses IScoreSaver — no legacy knowledge.");
            Console.WriteLine();
            SimulateGameWin(scoreSaver, "Diana");
            SimulateGameWin(scoreSaver, "Eve");
            Console.WriteLine();

            Console.WriteLine("  ✔ Adapter verified: IScoreSaver delegates to LegacyOldTextLogger seamlessly.");
        }

        private static void SimulateGameWin(IScoreSaver saver, string winner)
        {
            Console.WriteLine($"    Game: \"{winner}\" won! Saving via IScoreSaver...");
            saver.SaveWin(winner);
        }
    }
}
