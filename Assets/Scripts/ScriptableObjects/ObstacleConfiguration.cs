using Models;
using ObstacleModule.Components;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstacleConfiguration", menuName = "Create configuration/Obstacle configuration")]
    public class ObstacleConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("Assign the prefab that contains the ObstacleComponent.")] 
        private ObstacleComponent obstacleComponent;
        [SerializeField, Min(0.1f), Tooltip("The speed of the obstacle.")] 
        private float speed;
        [SerializeField, Min(0.1f), Tooltip("The life of the bullet after it was instantiated. (seconds)")] 
        private float obstacleLifeDuration;
        [SerializeField, Tooltip("The waiting time until the next obstacles will appear in scene. (seconds)")] 
        private Interval<float> waitingTimeInstantiatingObstacle;
        [SerializeField, Tooltip("The size of the obstacle.")] 
        private Interval<Vector3> obstacleSize;

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
