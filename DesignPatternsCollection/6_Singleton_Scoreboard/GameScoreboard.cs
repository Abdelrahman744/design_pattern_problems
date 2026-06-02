using System;

namespace DesignPatternsCollection.Singleton
{
    // Singleton — only one instance exists; accessed via GetInstance().
    public sealed class GameScoreboard
    {
        private static GameScoreboard? _instance;
        private static readonly object _instanceLock = new object();
        private readonly object _scoreLock = new object();
        private int _score;

        // Private constructor — prevents external instantiation.
        private GameScoreboard()
        {
            _score = 0;
            Console.WriteLine("  [GameScoreboard] 🎮 Singleton instance created. Score starts at 0.");
        }

        // Thread-safe access using double-checked locking.
        public static GameScoreboard GetInstance()
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new GameScoreboard();
                    }
                }
            }
            return _instance;
        }

        // Adds points to the shared score (thread-safe).
        public void AddPoints(int points)
        {
            lock (_scoreLock)
            {
                _score += points;
                Console.WriteLine($"  [GameScoreboard] ➕ Added {points} points  →  Total: {_score}");
            }
        }

        public int Score
        {
            get { lock (_scoreLock) { return _score; } }
        }

        // Resets the singleton for testing purposes only.
        internal static void ResetForTesting()
        {
            lock (_instanceLock)
            {
                _instance = null;
            }
        }
    }

    // Game object — collects coins and updates the singleton scoreboard.
    public class Coin
    {
        private readonly string _location;

        public Coin(string location)
        {
            _location = location;
        }

        public void Collect()
        {
            Console.WriteLine($"  🪙 Coin collected at {_location}!");
            GameScoreboard.GetInstance().AddPoints(10);
        }
    }

    // Game object — defeats enemies and updates the singleton scoreboard.
    public class Enemy
    {
        private readonly string _name;
        private readonly int _pointValue;
        private readonly bool _isBoss;

        public Enemy(string name, int pointValue, bool isBoss = false)
        {
            _name = name;
            _pointValue = pointValue;
            _isBoss = isBoss;
        }

        public void Defeat()
        {
            string label = _isBoss ? "👹 BOSS" : "👾 Enemy";
            Console.WriteLine($"  {label} \"{_name}\" defeated!");
            GameScoreboard.GetInstance().AddPoints(_pointValue);
        }
    }
}
