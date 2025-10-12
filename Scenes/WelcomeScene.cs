using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Scenes
{
    internal static class WelcomeScene
    {
        private static byte page = 1;

        private static Dictionary<byte, List<string>> pages = new Dictionary<byte, List<string>>()
        {
            {1, new List<string>()
                {
                    "Добро пожаловать",
                    "",
                    "Это минимально жизнеспособный продукт (MVP) основной игры Trojan",
                    "Прототип создан что бы посмотреть на основные механики со стороны",
                    "после прохождения обязательно оставьте отзыв где-нибудь",
                    "без отклика это не имеет смысла",
                    "",
                    "1/2",
                    "Enter"
                }
            },

            { 2, new List<string>()
                {
                "Сюжет:",
                "",
                "Поздравление: Вы были приняты на должность защитника систем!",
                "Вам необходимо вовремя исправлять критические ошибки крупной Компании.",
                "не ошибитесь!",
                "",
                "2/2",
                "Enter"
                }
            }
        };

        public static List<string> Text = new List<string>(pages[page]);

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    if (page != pages.Count)
                        Text = pages[++page];
                    else
                        GameState.CurrentScene = SceneManager.PlaceWork;
                    break;
            }
        }
    }
}