using MonoSingleton;
using StateModule.Models;
using UI.Managers;
using static StateModule.Globals.States;

namespace StateModule.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private GameState gameState = GameState.IntroGame;

        public bool IsInGameMode()
        {
            return gameState == GameState.StartGame;
        }

        public void SetGameState(State state)
        {
            var (localGameState, screen) = state.GetState();
            gameState = localGameState;
            state.InvokeStateActions();
            ScreenManager.Instance.SwitchScreen(screen);
        }
    }
}
