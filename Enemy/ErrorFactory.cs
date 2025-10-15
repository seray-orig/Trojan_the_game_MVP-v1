using System.Text;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Entities
{
    public static class ErrorFactory
    {
        private static readonly char[] spinnerChar = new char[] { '|', '/', '—', '\\' };
        private static int spinnerIndex = 0;

        private static int ErrorCode = 0;
        public static StringBuilder Error = new StringBuilder();
        private static List<string> ErrorList = new List<string>()
        {
            "",// Ошибок не обнаружено
            "",
        };

        private static void ErrorLogic()
        {

        }

        public static void CheckError()
        {
            spinner();
            ErrorLogic();
            Error.Clear();
            Error.Append(ErrorList[ErrorCode]);
        }

        private static void spinner()
        {
            if (GameState.CurrentFrame < 11)
                GameState.CurrentFrame++;
            else
                GameState.CurrentFrame = 1;

            if (GameState.CurrentFrame % 10 == 0)
            {
                spinnerIndex = (spinnerIndex + 1) % spinnerChar.Length;
            }

            ErrorList[0] = "Ошибок не обнаружено " + spinnerChar[spinnerIndex].ToString();
        }
    }
}
