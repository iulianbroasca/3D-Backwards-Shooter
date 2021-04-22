using Globals;
using UnityEngine;

namespace CharacterModule.Behaviours
{
    public class CharacterAssailedBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            States.GameOver.AddActionState(Assailed);
        }

        private void Assailed()
        {
            Debug.Log("Triggers the animation dies");
        }
    }
}
