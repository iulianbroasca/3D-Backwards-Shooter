using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "Create configuration/Game configuration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField, Range(6,10)] private float roadWidth;
        [SerializeField] private float gameDuration;
        [SerializeField] private int waitingTimeUntilGameStart;

        public float RoadWidth => roadWidth;

        public float GameDuration => gameDuration;

        public int WaitingTimeUntilGameStart => waitingTimeUntilGameStart;

    }
}
