using BulletModule.Components;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletConfiguration", menuName = "Create configuration/Bullet configuration")]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField] private BulletComponent bulletComponent;
        [SerializeField] private float bulletLifeDuration;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float waitingTimeNextBullet;

        public BulletComponent GetBulletComponent => bulletComponent;

        public float GetBulletLifeDuration => bulletLifeDuration;

        public float GetBulletSpeed => bulletSpeed;

        public float GetWaitingTimeNextBullet => waitingTimeNextBullet;
    }
}
