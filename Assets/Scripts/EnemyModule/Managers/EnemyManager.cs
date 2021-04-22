using System.Collections;
using EnemyModule.Pool;
using GameConfigurationModule.Managers;
using Globals;
using MonoSingleton;
using ScriptableObjects;
using StateModule.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyModule.Managers
{
    public class EnemyManager : MonoSingleton<EnemyManager>
    {
        private Coroutine instantiationCoroutine;
        private Transform enemySpawner;
        private EnemyPool enemyPool;

        private EnemyConfiguration enemyConfiguration;
        private float roadWidth;

        private int numberEnemiesPerGame;
        private int currentEnemiesShotDown;
        private int remainingEnemiesInstantiation;

        protected override void Awake()
        {
            base.Awake();

            enemySpawner = GameObject.FindGameObjectWithTag(Tags.EnemySpawner).transform;

            InitializeConfigurations();
            InitializeEnemyPool();
            InitializeStates();
        }

        public void EnemyShotDownByBullet()
        {
            currentEnemiesShotDown++;
            CheckNumberEnemiesShotDown();
        }

        public void EnemyShotDownByObstacle()
        {
            remainingEnemiesInstantiation++;
        }

        private void StartInstantiation()
        {
            instantiationCoroutine = StartCoroutine(InstantiateEnemies());
        }

        private void StopInstantiation()
        {
            if (instantiationCoroutine != null)
                StopCoroutine(instantiationCoroutine);
        }

        private IEnumerator InstantiateEnemies()
        {
            while (GameManager.Instance.IsInGameMode())
            {
                yield return new WaitForSeconds(enemyConfiguration.GetRandomWaitingTimeInstantiatingEnemies);
                InstantiateLineEnemies();
            }
        }

        private void InstantiateLineEnemies()
        {
            var enemies = GetNumberEnemiesPerLine();
            for (var i = 0; i < enemies; i++)
            {
                var enemy = enemyPool.GetObjectFromPool(false);
                enemy.InitializeEnemy(GetRandomSpawnPosition(), 
                    enemyConfiguration.GetSpeed, enemyConfiguration.GetBoost);
                enemy.gameObject.SetActive(true);
            }
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return enemySpawner.localPosition + Vector3.right * Random.Range(-1 * roadWidth / 2.0f, roadWidth / 2.0f);
        }

        private int GetNumberEnemiesPerLine()
        {
            var numberEnemies = enemyConfiguration.GetRandomNumberEnemiesPerLine;

            if (remainingEnemiesInstantiation - numberEnemies >= 0)
            {
                remainingEnemiesInstantiation -= numberEnemies;
            }
            else
            {
                numberEnemies = remainingEnemiesInstantiation;
            }

            return numberEnemies;
        }

        private void CheckNumberEnemiesShotDown()
        {
            if (numberEnemiesPerGame == currentEnemiesShotDown)
            {
                GameManager.Instance.SetGameState(States.GameWon);
            }
        }

        private void ResetManager()
        {
            currentEnemiesShotDown = 0;
            remainingEnemiesInstantiation = numberEnemiesPerGame;
        }

        private void InitializeConfigurations()
        {
            roadWidth = ConfigurationManager.Instance.GetConfiguration<GameConfiguration>().RoadWidth;
            enemyConfiguration = ConfigurationManager.Instance.GetConfiguration<EnemyConfiguration>();
            numberEnemiesPerGame = enemyConfiguration.GetNumberEnemiesInGame;
        }

        private void InitializeEnemyPool()
        {
            enemyPool = gameObject.AddComponent<EnemyPool>();
            enemyPool.RegisterComponent(enemyConfiguration.GetEnemyComponent);
            enemyPool.SetEnemyModuleConfigurations(enemyConfiguration.GetDeathDuration);
        }

        private void InitializeStates()
        {
            States.StartGame.AddActionState(StartInstantiation);
            States.StartGame.AddActionState(ResetManager);

            States.GameOver.AddActionState(StopInstantiation);
            States.GameWon.AddActionState(StopInstantiation);
        }
    }
}
