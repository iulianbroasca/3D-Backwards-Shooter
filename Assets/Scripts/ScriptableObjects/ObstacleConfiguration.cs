using Models;
using ObstacleModule.Components;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstacleConfiguration", menuName = "Create configuration/Obstacle configuration")]
    public class ObstacleConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("Prefab")] private ObstacleComponent obstacleComponent;
        [SerializeField] private float speed;
        [SerializeField, Tooltip("Seconds")] private float obstacleLifeDuration;
        [SerializeField, Tooltip("Seconds")] private Interval<float> waitingTimeInstantiatingObstacle;
        [SerializeField] private Interval<Vector3> obstacleSize;

        public ObstacleComponent GetObstacleComponent => obstacleComponent;

        public float GetSpeed => speed;

        public float GetObstacleLifeDuration => obstacleLifeDuration;

        public float GetRandomWaitingTimeInstantiatingObstacle =>
                Random.Range(waitingTimeInstantiatingObstacle.GetInterval().minimum,
                    waitingTimeInstantiatingObstacle.GetInterval().maximum);

        public Vector3 GetObstacleSize()
        {
            var minSize = obstacleSize.GetInterval().minimum;
            var maxSize = obstacleSize.GetInterval().maximum;

            return new Vector3(Random.Range(minSize.x, maxSize.x), 
                Random.Range(minSize.y, maxSize.y),
                Random.Range(minSize.z, maxSize.z));
        }
    }
}
