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
            "G - Утилита 5,",
            "H - Утилита 6,",

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
                    GameState.CurrentUtility = UtilOne.Run;
                    break;
            }
        }
    }
}
