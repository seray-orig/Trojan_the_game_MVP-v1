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
                    if (!Text.Contains("U - Открыть раздел утилит"))
                        Text.Add("U - Открыть раздел утилит");
                    UpdateSystem.SetInterface("Utilities");
                    break;
            }
        }
    }
}
