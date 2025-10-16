using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Enemy;

namespace Trojan_MVP_v1.Interfaces
{
    public static class Utilities
    {


        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    UpdateSystem.SetInterface("Basic");
                    break;
                case ConsoleKey.W:
                    GameState.IsErrorRun = false;
                    ErrorFactory.DifficultyLimiter += 3;
                    break;
            }
        }
    }
}
