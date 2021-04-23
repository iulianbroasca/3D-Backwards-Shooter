using EnemyModule.Components;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Create configuration/Enemy configuration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("Prefab")] private EnemyComponent enemyComponent;
        [SerializeField] private int numberEnemiesInGame;
        [SerializeField, Tooltip("Seconds")] private float deathDuration;
        [SerializeField] private float speed;
        [SerializeField, Tooltip("It will be applied when the character touches the wall")] private float boost;
        [SerializeField] private Interval<int> numberEnemiesPerLine;
        [SerializeField, Tooltip("Seconds")] private Interval<float> waitingTimeInstantiatingEnemies;

        public EnemyComponent GetEnemyComponent => enemyComponent;

        public int GetNumberEnemiesInGame => numberEnemiesInGame;

        public float GetDeathDuration => deathDuration;

        public float GetSpeed => speed;

        public float GetBoost => boost;

        public int GetRandomNumberEnemiesPerLine => 
            Random.Range(numberEnemiesPerLine.GetInterval().minimum, 
                numberEnemiesPerLine.GetInterval().maximum);

        public float GetRandomWaitingTimeInstantiatingEnemies => 
            Random.Range(waitingTimeInstantiatingEnemies.GetInterval().minimum,
                waitingTimeInstantiatingEnemies.GetInterval().maximum);
    }
}
