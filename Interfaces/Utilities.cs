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
            "Нажать:",
            "",
            "1 - Утилита 1,",
            "",
            "2 - Утилита 2,",
            "",
            "3 - Утилита 3,",
            "",
            "4 - Утилита 4,",
            "",
        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    UpdateSystem.SetInterface("Basic");
                    break;
                case ConsoleKey.D1:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 1;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.D2:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 2;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.D3:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 3;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.D4:
                    UpdateSystem.SetInterface("Basic");
                    if (!GameState.IsUtilityRun)
                    {
                        Utility.UtilityCode = 4;
                        GameState.CurrentUtility = Utility.Run;
                    }
                    break;
                case ConsoleKey.D5:
                    if (!Text.Contains("5 - Игра \"Змейка\""))
                    {
                        Text.Add("5 - Игра \"Змейка\"");
                        Text.Add("");
                    }
                    else
                    {
                        UpdateSystem.SetInterface("Basic");
                        if (!GameState.IsUtilityRun)
                        {
                            Utility.UtilityCode = 5;
                            GameState.CurrentUtility = Utility.Run;
                        }
                    }
                    break;
            }
        }
    }
}
