using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Scenes
{
    internal static class Welcome
    {
        private static byte page = 1;

        private static Dictionary<byte, List<string>> pages = new Dictionary<byte, List<string>>()
        {
            {1, new List<string>()
                {
                "Здарова",
                "",
                "Это минимально жизнеспособный продукт (MVP) основной игры Trojan",
                "Прототип игрового процесса создан что бы посмотреть на идейные механики со стороны",
                "после прохождения обязательно оставь отзыв где-нибудь",
                "без отклика это не имеет смысла",
                "(не меняй раймер консоли)",
                "",
                "1/2",
                "Enter"
                }
            },

            { 2, new List<string>()
                {
                "Сюжет:",
                "",
                "Поздравление: Вы были приняты на должность единственного защитника систем!",
                "Вам необходимо вовремя исправлять критические ошибки крупной компании.",
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
                        UpdateSystem.NextScene();
                    break;
            }
        }
    }
}