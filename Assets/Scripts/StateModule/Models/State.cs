using System;
using Globals;

namespace StateModule.Models
{
    public class State
    {
        private readonly States.GameState gameState;
        private readonly Type screen;
        private Action stateActions;

        public State(States.GameState state, Type screen)
        {
            gameState = state;
            this.screen = screen;
        }

        public (States.GameState gameState, Type screen) GetState()
        {
            return(gameState, screen);
        }

        public void AddActionState(Action action)
        {
            stateActions += action;
        }

        public void InvokeStateActions()
        {
            stateActions?.Invoke();
        }
    }
}
