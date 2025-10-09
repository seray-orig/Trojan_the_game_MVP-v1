using Trojan_MVP_v1.Interfaces;

namespace Trojan_MVP_v1.Core
{
    internal static class UpdateSystem
    {
        public static void Update()
        {
            // Обновляем игровые данные
            GameState.CurrentScene.Invoke();
        }
    }
}
