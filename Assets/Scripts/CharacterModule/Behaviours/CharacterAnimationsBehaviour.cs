using Globals;
using StateModule.Globals;
using UnityEngine;

namespace CharacterModule.Behaviours
{
    public class CharacterAnimationsBehaviour : MonoBehaviour
    {
        private Animator characterAnimator;

        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
            States.GameOver.AddActionState(()=>
            {
                SetTrigger(Constants.DeadTriggerAnimator);
            });

            States.IntroGame.AddActionState(() =>
            {
                SetTrigger(Constants.IdleTriggerAnimator);
            });

            States.GameWon.AddActionState(() =>
            {
                SetTrigger(Constants.WonTriggerAnimator);
            });

            States.StartGame.AddActionState(() =>
            {
                SetTrigger(Constants.RunningTriggerAnimator);
            });
        }

        private void SetTrigger(string triggerName)
        {
            characterAnimator.SetTrigger(triggerName);
        }
    }
}
