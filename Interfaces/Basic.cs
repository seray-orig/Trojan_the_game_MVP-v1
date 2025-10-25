using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Enemy;

namespace Trojan_MVP_v1.Interfaces
{
    internal static class Basic
    {
        public static List<string> Text = new List<string>()
        {
            "E - Открыть руководство",
        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.E:
                    UpdateSystem.SetInterface("Manual");
                    break;
                case ConsoleKey.U:
                    if (!Text.Contains("U - Выбрать утилиту"))
                        Text.Add("U - Выбрать утилиту");
                    UpdateSystem.SetInterface("Utilities");

                    if (ErrorFactory.ErrorCode == 10 && !Utilities.Text.Contains("5 - Игра \"Змейка\""))
                    {
                        Utilities.Text.Add("5 - Игра \"Змейка\"");
                        Utilities.Text.Add("");
                    }
                    break;
                case ConsoleKey.Spacebar:
                    if (GameState.IsErrorRun && ErrorFactory.ErrorCode == 8 && GameState.err8Clicks >= 29)
                    {
                        GameState.err8Clicks = 0;
                        ErrorFactory.ErrorSolve();
                    }
                    else if (GameState.IsErrorRun && ErrorFactory.ErrorCode == 8 && GameState.err8Clicks < 30)
                        GameState.err8Clicks++;
                    break;
                case ConsoleKey.P:
                    if (GameState.canEmail)
                    {
                        if (Text.Contains("P - Открыть почтовый ящик*"))
                            Text[2] = ("P - Открыть почтовый ящик");
                        UpdateSystem.SetInterface("Email");
                    }
                    break;
            }
        }
    }
}
