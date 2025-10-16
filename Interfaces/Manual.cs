using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Entities;

namespace Trojan_MVP_v1.Interfaces
{
    internal static class Manual
    {
        public static string BuildTitle()
        {
            var Title = new StringBuilder();
            Title.Append("Q - Закрыть руководство");
            if (GameState.IsErrorRun)
                Title.Append(" (" + ErrorFactory.ErrorTime.ToString() + " " + ErrorFactory.Error + ")");

            return Title.ToString();

        }

        public static List<string> Text = new List<string>()
        {
            "Добро пожаловать в руководство по устранению критических неисправностей в компании ?null? (R)все права защищены.",
            "Работать у нас - это огромная честь и вдохновляющий опыт. Здесь собрались талантливые специалисты, вроде вас,",
            "которые каждый день создают инновационные решения и двигают технологии вперёд.",
            "Забудьте, чему вас учили. Не сомневайтесь, здесь вы найдёте всё, что вам нужно знать.",
            "",
            "Во-первых запомните, у каждой ошибки есть свой код. (Критическая ошибка код: n <---)",
            "",
        };

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
