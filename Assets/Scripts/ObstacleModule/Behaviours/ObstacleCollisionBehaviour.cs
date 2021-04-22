using CharacterModule.Components;
using EnemyModule.Behaviours;
using EnemyModule.Components;
using UnityEngine;

namespace ObstacleModule.Behaviours
{
    public class ObstacleCollisionBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var enemy = other.gameObject.GetComponent<EnemyComponent>();
            if (enemy != null)
                enemy.TouchedByObstacle();

            if (other.gameObject.GetComponent<CharacterComponent>() != null)
                EnemyAttackBehaviour.IncreaseSpeed();
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.GetComponent<CharacterComponent>() != null)
                EnemyAttackBehaviour.DecreaseSpeed();
        }
    }
}
