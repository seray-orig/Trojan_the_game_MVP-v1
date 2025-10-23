using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trojan_MVP_v1.Core;

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
                    break;
            }
        }
    }
}
