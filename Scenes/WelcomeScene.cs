using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Scenes
{
    internal static class WelcomeScene
    {
        public static List<string> Text = new List<string>()
        {
            "Поздравляю! Вы были приняты на должность защитника систем.",
            "Вам необходимо вовремя исправлять поступающие ошибки крупной Компании.",
            "не ошибитесь!",
            " ",
            "Enter"
        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    GameState.CurrentScene = SceneManager.PlaceWork;
                    break;
            }
        }
    }
}