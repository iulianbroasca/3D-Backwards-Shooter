using BulletModule.Components;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletConfiguration", menuName = "Create configuration/Bullet configuration")]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("Assign the prefab that contains the BulletComponent.")] 
        private BulletComponent bulletComponent;
        [SerializeField, Min(0), Tooltip("The life of the bullet after it was instantiated. (seconds)")] 
        private float bulletLifeDuration;
        [SerializeField, Range(5,25), Tooltip("The force to be applied to the bullet.")] 
        private float bulletSpeed;
        [SerializeField, Min(0), Tooltip("The waiting time until the next bullet appears. (seconds)")] 
        private float waitingTimeNextBullet;

        public BulletComponent GetBulletComponent => bulletComponent;

        public float GetBulletLifeDuration => bulletLifeDuration;

        public float GetBulletSpeed => bulletSpeed;

        public float GetWaitingTimeNextBullet => waitingTimeNextBullet;
    }
}
