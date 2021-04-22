using System.Collections.Generic;
using System.Linq;
using Globals;
using MonoSingleton;
using UI.BaseScripts;
using UnityEngine;

namespace UI.Managers
{
    public class ScreenManager : MonoSingleton<ScreenManager>
    {
        private readonly Dictionary<object, BaseScreen> screens = new Dictionary<object, BaseScreen>();

        private GameObject rootCanvas;
        private BaseScreen currentBaseScreen;

        protected override void Awake()
        {
            base.Awake();
            Initialization();
        }

        public BaseScreen GetScreen(object screenType)
        {
            var screen = screens.First(it => it.Key == screenType);
            return screen.Value;
        }

        public void SwitchScreen(object screenType)
        {
            var lastScreen = currentBaseScreen;
            currentBaseScreen = GetScreen(screenType);

            lastScreen.RefreshScreen();
            lastScreen.DisableScreen();

            currentBaseScreen.EnableScreen();
        }

        protected void LoadScreens()
        {
            foreach (var screen in rootCanvas.GetComponentsInChildren<BaseScreen>(true))
            {
                screens.Add(screen.GetType(), screen);
                screen.InitializeScreen();
            }
        }

        private void Initialization()
        {
            rootCanvas = GameObject.FindWithTag(Tags.MainCanvas);
            LoadScreens();
            currentBaseScreen = GameObject.FindWithTag(Tags.StartScreen).GetComponent<BaseScreen>();
            currentBaseScreen.EnableScreen();
        }
    }
}