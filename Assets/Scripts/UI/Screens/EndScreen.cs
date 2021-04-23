using Globals;
using StateModule.Globals;
using StateModule.Managers;
using UI.BaseScripts;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EndScreen : BaseScreen
    {
        private Text statusGameText;
        private Button restartGameButton;

        private void OnEnable()
        {
            restartGameButton.gameObject.SetActive(true);
        }

        public override void InitializeScreen()
        {
            States.GameWon.AddActionState(GameWon);
            States.GameOver.AddActionState(GameOver);

            statusGameText = transform.GetComponentInChildren<Text>();
            restartGameButton = transform.GetComponentInChildren<Button>();

            restartGameButton.onClick.AddListener(RestartGameFunctionality);
        }

        private void GameWon()
        {
            statusGameText.text = Constants.GameWon;
        }

        private void GameOver()
        {
            statusGameText.text = Constants.GameOverText;
        }

        private void RestartGameFunctionality()
        {
            GameManager.Instance.SetGameState(States.IntroGame);
            restartGameButton.gameObject.SetActive(false);
        }
    }
}
