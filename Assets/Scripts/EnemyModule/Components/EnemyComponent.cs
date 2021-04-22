using System;
using EnemyModule.Behaviours;
using EnemyModule.Managers;
using EnemyModule.Pool;
using Globals;
using UnityEngine;

namespace EnemyModule.Components
{
    [RequireComponent(typeof(EnemyAttackBehaviour))]
    [RequireComponent(typeof(EnemyCollisionBehaviour))]
    [RequireComponent(typeof(EnemyDeathBehaviour))]
    public class EnemyComponent : MonoBehaviour
    {
        private static EnemyPool enemyPool;

        private EnemyAttackBehaviour enemyAttackBehaviour;
        private EnemyDeathBehaviour enemyDeathBehaviour;
        private Rigidbody rigidbodyComponent;

        private EnemyAttackBehaviour EnemyAttackBehaviour
        {
            get
            {
                if (enemyAttackBehaviour == null)
                    enemyAttackBehaviour = GetComponentInChildren<EnemyAttackBehaviour>();
                return enemyAttackBehaviour;
            }
        }
        private EnemyDeathBehaviour EnemyDeathBehaviour
        {
            get
            {
                if (enemyDeathBehaviour == null)
                    enemyDeathBehaviour = GetComponentInChildren<EnemyDeathBehaviour>();
                return enemyDeathBehaviour;
            }
        }
        private Rigidbody RigidbodyComponent
        {
            get
            {
                if (rigidbodyComponent == null)
                    rigidbodyComponent = GetComponent<Rigidbody>();
                return rigidbodyComponent;
            }
        }

        private bool hit;

        private void Awake()
        {
            InitializeStates();
        }

        public void InitializeEnemy(Vector3 position, float speed, float boost)
        {
            ResetRigidbodyComponent();
            transform.localPosition = position;
            transform.localEulerAngles = Vector3.zero;
            EnemyAttackBehaviour.InitializeEnemyAttack(speed, boost);
            hit = false;
        }

        public void SetEnemyConfigurations(float deathDuration, EnemyPool pool)
        {
            EnemyDeathBehaviour.SetConfigurations(deathDuration);
            enemyPool = pool;
        }

        public void TouchedByBullet()
        {
            Touched(EnemyManager.Instance.EnemyShotDownByBullet);
        }

        public void TouchedByObstacle()
        {
            Touched(EnemyManager.Instance.EnemyShotDownByObstacle);
        }

        private void Touched(Action shotDown)
        {
            if (hit)
                return;
            hit = true;
            EnemyDeathBehaviour.EnemyDeath(AddToPool);
            EnemyAttackBehaviour.ShotDown();
            shotDown.Invoke();
        }

        private void ResetRigidbodyComponent()
        {
            RigidbodyComponent.velocity = Vector3.zero;
            RigidbodyComponent.angularVelocity = Vector3.zero;
        }

        private void RestartGameAction()
        {
            if(gameObject.activeSelf)
                AddToPool();
        }

        private void AddToPool()
        {
            enemyPool.AddObjectToPool(this);
        }

        private void InitializeStates()
        {
            States.IntroGame.AddActionState(RestartGameAction);
        }
    }
}
