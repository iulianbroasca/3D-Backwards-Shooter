using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletConfiguration", menuName = "Create configuration/Bullet configuration")]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField] private BulletComponent bulletGameObject;
        [SerializeField] private float bulletLifeDuration;
        [SerializeField] private float bulletSpeed;

        public BulletComponent BulletGameObject => bulletGameObject;

        public float BulletLifeDuration => bulletLifeDuration;

        public float BulletSpeed => bulletSpeed;
    }
}
