using Globals;
using MonoSingleton;
using StateModule.Models;
using UI.Managers;
using UnityEngine;
using static StateModule.Globals.States;

namespace StateModule.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private GameState gameState = GameState.IntroGame;
        private ScreenManager screenManager;

        protected override void Awake()
        {
            base.Awake();
            screenManager = GameObject.FindGameObjectWithTag(Tags.Managers).GetComponentInChildren<ScreenManager>();
        }

        public bool IsInGameMode()
        {
            return gameState == GameState.StartGame;
        }

        public void SetGameState(State state)
        {
            var (localGameState, screen) = state.GetState();
            gameState = localGameState;
            state.InvokeStateActions();
            screenManager.SwitchScreen(screen);
        }
    }
}
