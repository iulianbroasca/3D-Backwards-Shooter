using System.Collections;
using GameConfigurationModule.Managers;
using Globals;
using MonoSingleton;
using ObstacleModule.Pool;
using ScriptableObjects;
using StateModule.Globals;
using StateModule.Managers;
using UnityEngine;

namespace ObstacleModule.Managers
{
    public class ObstacleManager : MonoSingleton<ObstacleManager>
    {
        private ObstacleConfiguration obstacleConfiguration;
        private Coroutine instantiationCoroutine;
        private Transform obstacleSpawner;
        private ObstaclePool obstaclePool;
        private float roadWidth;

        protected override void Awake()
        {
            base.Awake();
            obstacleSpawner = GameObject.FindGameObjectWithTag(Tags.ObstacleSpawner).transform;

            InitializeConfigurations();
            InitializeObstaclePool();
            InitializeStates();
        }

        private void StartInstantiation()
        {
            instantiationCoroutine = StartCoroutine(InstantiateEnemiesCoroutine());
        }

        private void StopInstantiation()
        {
            if (instantiationCoroutine != null)
                StopCoroutine(instantiationCoroutine);
        }

        private IEnumerator InstantiateEnemiesCoroutine()
        {
            while (GameManager.Instance.IsInGameMode())
            {
                yield return new WaitForSeconds(obstacleConfiguration.GetRandomWaitingTimeInstantiatingObstacle);
                InstantiateObstacle();
            }
        }

        private void InstantiateObstacle()
        {
            var obstacle = obstaclePool.GetObjectFromPool();
            obstacle.InitializeObstacle(obstacleConfiguration.GetSpeed, 
                GetRandomSpawnPosition(),
                obstacleConfiguration.GetObstacleSize());
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return obstacleSpawner.localPosition + Vector3.right * Random.Range(-1 * roadWidth / 2.0f, roadWidth / 2.0f);
        }

        private void InitializeConfigurations()
        {
            roadWidth = ConfigurationManager.Instance.GetConfiguration<GameConfiguration>().RoadWidth;
            obstacleConfiguration = ConfigurationManager.Instance.GetConfiguration<ObstacleConfiguration>();
        }

        private void InitializeObstaclePool()
        {
            obstaclePool = gameObject.AddComponent<ObstaclePool>();
            obstaclePool.RegisterComponent(obstacleConfiguration.GetObstacleComponent);
            obstaclePool.SetObstacleModuleConfigurations(obstacleConfiguration.GetObstacleLifeDuration);
        }

        private void InitializeStates()
        {
            States.StartGame.AddActionState(StartInstantiation);
            States.GameOver.AddActionState(StopInstantiation);
            States.GameWon.AddActionState(StopInstantiation);
        }
    }
}
