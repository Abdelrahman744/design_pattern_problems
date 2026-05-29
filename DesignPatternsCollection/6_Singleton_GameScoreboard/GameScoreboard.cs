using System;

namespace DesignPatternsCollection.Singleton
{
    public sealed class GameScoreboard
    {
        private static GameScoreboard? _instance;
        private static readonly object _instanceLock = new object();
        private readonly object _scoreLock = new object();
        private int _score;

        private GameScoreboard()
        {
            _score = 0;
            Console.WriteLine("  [GameScoreboard] 🎮 Singleton instance created. Score starts at 0.");
        }

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

        internal static void ResetForTesting()
        {
            lock (_instanceLock)
            {
                _instance = null;
            }
        }
    }

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
