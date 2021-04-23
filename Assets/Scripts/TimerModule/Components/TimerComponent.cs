using GameConfigurationModule.Managers;
using ScriptableObjects;
using StateModule.Managers;
using System.Collections;
using UnityEngine;
using static StateModule.Globals.States;

namespace TimerModule.Components
{
    public class TimerComponent : MonoBehaviour
    {
        private Coroutine instantiationCoroutine;
        private float gameDuration;

        protected void Awake()
        {
            InitializeConfigurations();
            InitializeStates();
        }

        private void StartTimer()
        {
            instantiationCoroutine = StartCoroutine(Timer());
        }

        private void StopTimer()
        {
            if (instantiationCoroutine != null)
                StopCoroutine(instantiationCoroutine);
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(gameDuration);
            GameManager.Instance.SetGameState(GameWon);
        }

        private void InitializeConfigurations()
        {
            gameDuration = ConfigurationManager.Instance.GetConfiguration<GameConfiguration>().GameDuration;
        }

        private void InitializeStates()
        {
            StartGame.AddActionState(StartTimer);

            GameOver.AddActionState(StopTimer);
            GameWon.AddActionState(StopTimer);
        }
    }
}
