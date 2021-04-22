namespace StateModule.Interfaces
{
    public interface IStateAction
    {
        void RestartGameAction();
        void StartGameAction();
        void EndGameWonAction();
        void EndGameLostAction();
    }
}
