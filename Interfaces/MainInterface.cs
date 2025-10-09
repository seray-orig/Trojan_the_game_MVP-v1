using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Interfaces
{
    internal static class MainInterface
    {
        public static List<string> Text = new List<string>()
        {
            "Esc - Закрыть игру",
            "E - Открыть инструкцию"
        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.E:
                    Console.WriteLine("Двигаемся вверх!");
                    break;
            }
        }
    }
}
