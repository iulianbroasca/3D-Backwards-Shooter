using System.Collections;
using GameConfigurationModule.Managers;
using ScriptableObjects;
using StateModule.Managers;
using UI.BaseScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class StartScreen : BaseScreen
    {
        private Text counter;
        private Button startGameButton;        
        
        private void Awake()
        {
            counter = transform.GetComponentInChildren<Text>();
            startGameButton = transform.GetComponentInChildren<Button>();

            startGameButton.onClick.AddListener(StartGameButton);
        }

        public override void DisableScreen()
        {
            base.DisableScreen();
            counter.text = string.Empty;
        }

        private void StartGameButton()
        {
            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            var duration = ConfigurationManager.Instance.GetConfiguration<GameConfiguration>().WaitingTimeUntilGameStart;
            while (duration != 0)
            {
                counter.text = duration.ToString();
                yield return new WaitForSeconds(1f);
                duration--;
            }

            GameManager.Instance.StartGame();
        }
    }
}
