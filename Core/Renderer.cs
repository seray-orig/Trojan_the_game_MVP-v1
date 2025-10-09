using System.Text;

namespace Trojan_MVP_v1.Core
{
    internal static class Renderer
    {
        public static void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(GameState.PlayerInterface.ToString());
        }
    }
}
