using Trojan_MVP_v1.Core;

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
            }
        }
    }
}
