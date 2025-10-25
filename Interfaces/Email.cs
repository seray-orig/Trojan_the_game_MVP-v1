

using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Enemy;

namespace Trojan_MVP_v1.Interfaces
{
    internal static class Email
    {
        public static bool showEnterButton = true;

        public static string Title = "Q - Вернуться на рабочий стол";

        public static List<string> EngiText = new List<string>()
        {
            "Привет, новенький. Я серверный инженер в этой компании.",
            "С начала рабочего дня от тебя ни слуху, ни духу.",
            "Дай угадаю, тебе забыли дать мои контакты?",

            "Злая шутка. Нам ведь придётся работать вместе.",
            "Качество серверов оставляет желать лучшего.",
            "Вряд-ли в первый день ты столкнёшся с этим...",
            "НО! если появиться ошибка с кодом 7, то сразу пиши мне.",
            "Это уже по моей части.",

            "Блин! А чё ты молчал? С этим нельзя медлить! щас проверю",

            "Я поправил провода, там был плохой контакт. Что сейчас?",

            "Отлично. Ну ты напугал меня. В следующий раз пиши сразу мне.",
        };

        public static List<string> UrText = new List<string>()
        {
            "Да, мне не сказали.",

            "У меня сейчас критическая ошибка код: 7.",

            "Исправлено.",
        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    UpdateSystem.SetInterface("Basic");
                    break;
                case ConsoleKey.Enter:
                    if (showEnterButton)
                    {
                        showEnterButton = false;
                        GameState.emailState++;
                    }
                    break;
            }
        }
    }
}
