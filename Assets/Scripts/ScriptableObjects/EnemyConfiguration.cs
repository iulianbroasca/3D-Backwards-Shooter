using EnemyModule.Components;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Create configuration/Enemy configuration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] private EnemyComponent enemyComponent;
        [SerializeField] private int numberEnemiesInGame;
        [SerializeField] private float deathDuration;
        [SerializeField] private float speed;
        [SerializeField] private float boost;
        [SerializeField] private Interval<int> numberEnemiesPerLine;
        [SerializeField] private Interval<float> waitingTimeInstantiatingEnemies;

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
