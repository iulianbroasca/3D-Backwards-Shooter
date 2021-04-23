using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "Create configuration/Game configuration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField, Range(6,10), Tooltip("Influences the width of the road. (meters)")] 
        private float roadWidth;
        [SerializeField, Min(1), Tooltip("Time until the end of the game. (seconds)")] 
        private float gameDuration;
        [SerializeField, Min(0), Tooltip("Counter before the game starts. (seconds)")] 
        private int waitingTimeUntilGameStart;

        public float RoadWidth => roadWidth;

        public float GameDuration => gameDuration;

        public int WaitingTimeUntilGameStart => waitingTimeUntilGameStart;

    }
}
