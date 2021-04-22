using System.Collections;
using BulletModule.Behaviours;
using BulletModule.Pool;
using UnityEngine;

namespace BulletModule.Components
{
    [RequireComponent(typeof(BulletCollisionBehaviour))]
    public class BulletComponent : MonoBehaviour
    {
        private static float bulletSpeed;
        private static float bulletLifeDuration;
        private static BulletPool bulletPool;

        private Coroutine coroutine;
        private Rigidbody rigidbodyComponent;
        private Rigidbody RigidbodyComponent
        {
            get
            {
                if (rigidbodyComponent == null)
                    rigidbodyComponent = GetComponent<Rigidbody>();
                return rigidbodyComponent;
            }
        }

        public void SetBulletConfigurations(float speed, float lifeDuration, BulletPool pool)
        {
            bulletSpeed = speed;
            bulletLifeDuration = lifeDuration;
            bulletPool = pool;
        }

        public void Shoot(Transform gun)
        {
            transform.position = gun.position;
            RigidbodyComponent.velocity = bulletSpeed * gun.forward;
            coroutine = StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(bulletLifeDuration);
            gameObject.SetActive(false);
        }

        private void ResetRigidbodyComponent()
        {
            RigidbodyComponent.velocity = Vector3.zero;
            RigidbodyComponent.angularVelocity = Vector3.zero;
        }

        private void AddToPool()
        {
            bulletPool?.AddObjectToPool(this);
        }

        private void OnDisable()
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            AddToPool();
            ResetRigidbodyComponent();
        }
    }
}
