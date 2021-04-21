using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstacleConfiguration", menuName = "Create configuration/Obstacle configuration")]
    public class ObstacleConfiguration : ScriptableObject
    {
        [SerializeField] private Interval<float> speedInterval;
        [SerializeField] private Interval<float> waitingTimeInstantiatingObstacle;
        [SerializeField] private Interval<Vector3> obstacleSize;

        public Interval<float> SpeedInterval => speedInterval;

        public Interval<float> WaitingTimeInstantiatingObstacle => waitingTimeInstantiatingObstacle;

        public Interval<Vector3> ObstacleSize => obstacleSize;
    }
}
