using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "Create configuration/Game configuration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private float gameDuration;
        [SerializeField] private int waitingTimeUntilGameStart;

        public float GameDuration => gameDuration;

        public int WaitingTimeUntilGameStart => waitingTimeUntilGameStart;
    }
}
