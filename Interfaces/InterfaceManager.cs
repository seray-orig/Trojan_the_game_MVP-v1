using System.Text;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Interfaces
{
    internal static class InterfaceManager
    {
        private static StringBuilder Interface = new StringBuilder();

        private static void BuildInterface(List<string> Text)
        {
            Interface.Clear();
            int xPos = 0;
            int yPos = 0;
            int padding = 3; // расстояние между элементами

            foreach (var hotkey in Text)
            {
                // Если элемент не помещается на текущую строку — перенос
                if (xPos + hotkey.Length > GameState.ConsoleWidth)
                {
                    Interface.AppendLine();
                    yPos++; xPos = 0;
                }

                // Добавляем отступ, если не в начале строки
                if (xPos > 0)
                {
                    Interface.Append(new string(' ', padding));
                    xPos += padding;
                }
                Interface.Append(hotkey);
                xPos += hotkey.Length;
            }

            // Разделительная линия под интерфейсом
            Interface.AppendLine();
            Interface.Append(new string('_', GameState.ConsoleWidth));

            GameState.PlayerInterface = Interface;
        }

        public static void InterfaceMain()
        {
            BuildInterface(MainInterface.Text);
            InputHandler.CurrentKeyHandler = MainInterface.HotKeys;
        }
    }
}
