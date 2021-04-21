using Globals;
using MonoSingleton;
using StateModule.Models;
using UI.Managers;

namespace StateModule.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private States.GameState gameState;

        public void RestartGame()
        {
            SetGameState(States.StartGame);
        }

        public void StartGame()
        {
            SetGameState(States.Game);
        }

        public void EndGameWon()
        {
            SetGameState(States.EndGameWon);
        }

        public void EndGameLost()
        {
            SetGameState(States.EndGameLost);
        }

        private void SetGameState(State state)
        {
            var (localGameState, screen) = state.GetState();
            gameState = localGameState;
            ScreenManager.Instance.SwitchScreen(screen);
        }
    }
}
