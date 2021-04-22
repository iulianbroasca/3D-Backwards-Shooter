using EnemyModule.Components;
using UnityEngine;

namespace BulletModule.Behaviours
{
    public class BulletCollisionBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var enemy = other.gameObject.GetComponent<EnemyComponent>();
            if (enemy == null) 
                return;

            enemy.TouchedByBullet();
            gameObject.SetActive(false);
        }
    }
}
