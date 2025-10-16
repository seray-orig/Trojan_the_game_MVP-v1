using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Scenes
{
    internal static class GameOver
    {
        static GameOver()
        {
            if (GameState.PlayerWin)
            {
                Text.Add("Вы спасли компанию, лучший работник!");
                Text.Add("(победа, спасибо за игру)");
            }
            else
            {
                Text.Add("Система компании была уничтожена из-за ужасной архитектуры");
                Text.Add("(поражение)");
            }
        }

        public static List<string> Text = new List<string>();
    }
}
