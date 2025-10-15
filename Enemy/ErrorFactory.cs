using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trojan_MVP_v1.Entities
{
    public static class ErrorFactory
    {
        private static int frameCounter = 0;
        private static readonly char[] spinner = new char[] { '|', '/', '—', '\\' };
        private static int spinnerIndex = 0;

        public static List<string> Error = new List<string>()
        {
            " ",
        };
        static ErrorFactory()
        {

        }

        public static void CheckError()
        {
            Error[0] = NoErrors();
        }

        private static string NoErrors()
        {
            var Text = "Ошибок не обнаружено ";

            frameCounter++;
            if (frameCounter % 10 == 0)
            {
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
            }

            return Text + spinner[spinnerIndex].ToString();
        }
    }
}
