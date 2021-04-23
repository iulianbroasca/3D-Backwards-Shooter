using EnemyModule.Components;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Create configuration/Enemy configuration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("Assign the prefab that contains the EnemyComponent.")] 
        private EnemyComponent enemyComponent;
        [SerializeField, Min(1), Tooltip("The total number of enemies that will be in the game.")] 
        private int numberEnemiesInGame;
        [SerializeField, Min(0), Tooltip("Duration until the enemy disappears. (seconds)")] 
        private float deathDuration;
        [SerializeField, Min(0.1f), Tooltip("The default speed of the enemy.")] 
        private float speed;
        [SerializeField, Min(0), Tooltip("Extra applied speed when the character touches a wall.")] 
        private float boost;
        [SerializeField, Tooltip("The number of enemies that will be instantiated in line.")] 
        private Interval<int> numberEnemiesPerLine;
        [SerializeField, Tooltip(" The waiting time until the next enemies will appear in scene. (seconds)")] 
        private Interval<float> waitingTimeInstantiatingEnemies;

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
