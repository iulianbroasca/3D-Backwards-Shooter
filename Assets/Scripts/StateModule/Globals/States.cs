using StateModule.Models;
using UI.Screens;

namespace StateModule.Globals
{
    public static class States
    {
        public static readonly State IntroGame = new State(GameState.IntroGame, typeof(StartScreen));
        public static readonly State StartGame = new State(GameState.StartGame, typeof(GameScreen));
        public static readonly State GameWon = new State(GameState.GameWon, typeof(EndScreen));
        public static readonly State GameOver = new State(GameState.GameOver, typeof(EndScreen));

        public enum GameState
        {
            IntroGame,
            StartGame,
            GameWon,
            GameOver
        }
    }
}
