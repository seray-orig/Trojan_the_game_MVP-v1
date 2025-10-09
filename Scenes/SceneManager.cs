using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Scenes
{
    internal static class SceneManager
    {
        public static void SceneWelcome()
        {
            GameState.CurrentUI = "WelcomeScene";
            Renderer.Center(WelcomeScene.Text);
            InputHandler.CurrentKeyHandler = WelcomeScene.HotKeys;
        }

        public static void PlaceWork()
        {
            GameState.CurrentUI = "PlaceWork";
            Renderer.Center(Workplace.Text);
            InputHandler.CurrentKeyHandler = Workplace.HotKeys;
        }
    }
}
