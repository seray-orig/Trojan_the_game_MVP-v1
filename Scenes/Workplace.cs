using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Scenes
{
    internal static class Workplace
    {
        public static List<string> Text = new List<string>()
        {
            "Алё"
        };

        public static void HotKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.E:
                    Game.Shutdown();
                    break;
            }
        }
    }
}
