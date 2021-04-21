using StateModule.Models;
using UI.Screens;

namespace Globals
{
    public static class States
    {
        public static readonly State StartGame = new State(GameState.StartGame, typeof(StartScreen));
        public static readonly State Game = new State(GameState.Game, typeof(GameScreen));
        public static readonly State EndGameWon = new State(GameState.EndGameWon, typeof(EndScreen));
        public static readonly State EndGameLost = new State(GameState.EndGameLost, typeof(EndScreen));

        public enum GameState
        {
            StartGame,
            Game,
            EndGameWon,
            EndGameLost
        }
    }
}
