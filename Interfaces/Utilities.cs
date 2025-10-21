using System.Text;
using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Weapons;

namespace Trojan_MVP_v1.Interfaces
{
    public static class Utilities
    {
        public static string BuildTitle()
        {
            var Title = new StringBuilder();
            Title.Append("Q - Вернуться на рабочий стол");
            if (GameState.IsErrorRun)
                Title.Append(" (Внимание!)");

            return Title.ToString();

        }

        public static List<string> Text = new List<string>()
        {
            "A - Утилита 1,",
            "S - Утилита 2,",
            "D - Утилита 3,",
            "F - Утилита 4,",

        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    UpdateSystem.SetInterface("Basic");
                    break;
                case ConsoleKey.A:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 1;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.S:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 2;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.D:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 3;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.F:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 4;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
            }
        }
    }
}
