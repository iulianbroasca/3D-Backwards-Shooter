using System.Collections;
using Globals;
using ObstacleModule.Behaviours;
using ObstacleModule.Pool;
using StateModule.Globals;
using StateModule.Managers;
using UnityEngine;

namespace ObstacleModule.Components
{
    [RequireComponent(typeof(ObstacleMovementBehaviour))] 
    public class ObstacleComponent : MonoBehaviour
    {
        private static ObstaclePool obstaclePool;
        private static float obstacleLifeDuration;

        private Coroutine coroutine;
        private ObstacleMovementBehaviour obstacleMovementBehaviour;
        private ObstacleMovementBehaviour ObstacleMovementBehaviour
        {
            get
            {
                if (obstacleMovementBehaviour == null)
                    obstacleMovementBehaviour = GetComponentInChildren<ObstacleMovementBehaviour>();
                return obstacleMovementBehaviour;
            }
        }

        private void Awake()
        {
            States.IntroGame.AddActionState(RestartGameAction);
        }

        public void InitializeObstacle(float speed, Vector3 position, Vector3 scale)
        {
            transform.localPosition = position;
            transform.localScale = scale;
            ObstacleMovementBehaviour.InitializeObstacleMovement(speed);
            coroutine = StartCoroutine(Destroy());
        }

        public void SetObstacleConfigurations(ObstaclePool pool, float lifeDuration)
        {
            obstaclePool = pool;
            obstacleLifeDuration = lifeDuration;
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(obstacleLifeDuration);
            if(GameManager.Instance.IsInGameMode())
                obstaclePool?.AddObjectToPool(this);
        }

        private void RestartGameAction()
        {
            if (gameObject.activeSelf)
                AddToPool();
        }

        private void AddToPool()
        {
            obstaclePool?.AddObjectToPool(this);
        }

        private void OnDisable()
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
        }
    }
}
