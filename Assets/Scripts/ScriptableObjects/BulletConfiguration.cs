using BulletModule.Components;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletConfiguration", menuName = "Create configuration/Bullet configuration")]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("Prefab")] private BulletComponent bulletComponent;
        [SerializeField, Tooltip("Seconds")] private float bulletLifeDuration;
        [SerializeField, Range(5,25), Tooltip("Velocity")] private float bulletSpeed;
        [SerializeField, Tooltip("Seconds")] private float waitingTimeNextBullet;

        public BulletComponent GetBulletComponent => bulletComponent;

        public float GetBulletLifeDuration => bulletLifeDuration;

        public float GetBulletSpeed => bulletSpeed;

        public float GetWaitingTimeNextBullet => waitingTimeNextBullet;
    }
}
