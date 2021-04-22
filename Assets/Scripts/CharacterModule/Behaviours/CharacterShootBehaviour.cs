using System.Collections;
using BulletModule.Pool;
using GameConfigurationModule.Managers;
using Globals;
using ScriptableObjects;
using StateModule.Managers;
using UnityEngine;

namespace CharacterModule.Behaviours
{
    public class CharacterShootBehaviour : MonoBehaviour
    {
        private Coroutine instantiationCoroutine;
        private BulletPool bulletPool;
        private BulletConfiguration bulletConfiguration;

        private void Awake()
        {
            bulletConfiguration = ConfigurationManager.Instance.GetConfiguration<BulletConfiguration>();
            InitializeBulletPool();
            InitializeStates();
        }

        private void StartInstantiation()
        {
            instantiationCoroutine = StartCoroutine(InstantiateBullets());
        }

        private void StopInstantiation()
        {
            if (instantiationCoroutine != null)
                StopCoroutine(instantiationCoroutine);
        }

        private IEnumerator InstantiateBullets()
        {
            while (GameManager.Instance.IsInGameMode())
            {
                yield return new WaitForSeconds(bulletConfiguration.GetWaitingTimeNextBullet);
                InstantiateBullet();
            }
        }

        private void InstantiateBullet()
        {
            var bullet = bulletPool.GetObjectFromPool();
            bullet.Shoot(transform);
        }

        private void InitializeBulletPool()
        {
            bulletPool = gameObject.AddComponent<BulletPool>();
            bulletPool.RegisterComponent(bulletConfiguration.GetBulletComponent);
            bulletPool.SetBulletConfigurations(bulletConfiguration.GetBulletSpeed, bulletConfiguration.GetBulletLifeDuration);
        }

        private void InitializeStates()
        {
            States.StartGame.AddActionState(StartInstantiation);
            States.GameOver.AddActionState(StopInstantiation);
            States.GameWon.AddActionState(StopInstantiation);
        }
    }
}
