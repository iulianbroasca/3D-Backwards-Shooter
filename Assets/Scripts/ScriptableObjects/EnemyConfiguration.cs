using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Create configuration/Enemy configuration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] private EnemyComponent enemyGameObject;
        [SerializeField] private int numberEnemiesInGame;
        [SerializeField] private Interval<float> speedInterval;
        [SerializeField] private Interval<int> numberEnemiesPerLine;
        [SerializeField] private Interval<float> waitingTimeInstantiatingEnemies;

        public EnemyComponent EnemyGameObject => enemyGameObject;

        public int NumberEnemiesInGame => numberEnemiesInGame;

        public Interval<float> SpeedInterval => speedInterval;

        public Interval<int> NumberEnemiesPerLine => numberEnemiesPerLine;

        public Interval<float> WaitingTimeInstantiatingEnemies => waitingTimeInstantiatingEnemies;
    }
}
