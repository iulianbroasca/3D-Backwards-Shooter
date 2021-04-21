using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "Create configuration/Game configuration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private float gameDuration;
        [SerializeField] private float waitingTimeUntilGameStart;

        public float GameDuration => gameDuration;

        public float WaitingTimeUntilGameStart => waitingTimeUntilGameStart;
    }
}
