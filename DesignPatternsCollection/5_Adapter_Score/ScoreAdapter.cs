using System;

namespace DesignPatternsCollection.Adapter
{
    // Adapter — bridges IScoreSaver (Target) to LegacyOldTextLogger (Adaptee).
    // Translates: SaveWin(player) → WriteLogEntry(date, text)
    public class ScoreAdapter : IScoreSaver
    {
        private readonly LegacyOldTextLogger _legacyLogger;

        public ScoreAdapter(LegacyOldTextLogger legacyLogger)
        {
            _legacyLogger = legacyLogger;
        }

        public void SaveWin(string player)
        {
            // Translate the modern call into the legacy format.
            string date    = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"WINNER recorded — Player: {player}";

            _legacyLogger.WriteLogEntry(date, message);
        }
    }
}
