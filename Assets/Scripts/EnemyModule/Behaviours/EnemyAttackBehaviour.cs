using StateModule.Managers;
using UnityEngine;

namespace EnemyModule.Behaviours
{
    public class EnemyAttackBehaviour : MonoBehaviour
    {
        public static Vector3 playerPosition;
        private static float boost;
        private static float speed;
        private bool dead;

        private void Update()
        {
            if (dead || !GameManager.Instance.IsInGameMode())
                return;
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        }

        public void InitializeEnemyAttack(float enemySpeed, float enemyBoost)
        {
            speed = enemySpeed;
            dead = false;
            boost = enemyBoost;
        }

        public void ShotDown()
        {
            dead = true;
        }

        public static void IncreaseSpeed()
        {
            speed += boost;
        }

        public static void DecreaseSpeed()
        {
            speed += boost;
        }
    }
}
