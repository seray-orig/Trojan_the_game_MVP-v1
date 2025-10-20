using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Enemy;

namespace Trojan_MVP_v1.Weapons
{
    internal static class UtilOne
    {
        private static string Title = "Утилита 1";
        private static DateTime _start;
        private static TimeSpan _end;
        private static bool idkHowElseToImplementThis = false;
        private static bool _canStart = false;
        private static bool _solve = false;

        public static void Run()
        {
            if (!idkHowElseToImplementThis)
            {
                _start = DateTime.Now;
                idkHowElseToImplementThis = true;
            }
            _end = DateTime.Now - _start;
            GameState.CurrentUtilityTitle.Clear();
            GameState.CurrentUtilityTitle.Append(Title);
            GameState.IsUtilityRun = true;

            if (_end.Seconds < 5 && !_solve)
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Проверка наличия рядовых критических ошибок.");
            }
            else if (!_canStart)
            {
                idkHowElseToImplementThis = false;
                _canStart = true;
            }
            else
            {
                _canStart = false;
                idkHowElseToImplementThis = false;
                GameState.IsUtilityRun = false;
                GameState.CurrentUtility = null;
            }

            if (_canStart && ErrorFactory.ErrorCode == 1 && GameState.IsErrorRun)
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Исправлено.");
                idkHowElseToImplementThis = true;
                _solve = true;
            }
            else if (_solve && _end.Seconds < 10)
            {
                GameState.IsErrorRun = false;
                ErrorFactory.ErrorTime.Clear();
                ErrorFactory.DifficultyLimiter += 3;
            }
            else if (!_solve && _canStart)
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Не обнаружено.");
            }
        }
    }
}
