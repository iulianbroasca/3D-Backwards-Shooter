using CharacterModule.Components;
using Globals;
using StateModule.Managers;
using UnityEngine;

namespace EnemyModule.Behaviours
{
    public class EnemyCollisionBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<CharacterComponent>() != null)
                GameManager.Instance.SetGameState(States.GameOver);
        }
    }
}
