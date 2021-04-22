using System;
using System.Collections;
using UnityEngine;

namespace EnemyModule.Behaviours
{
    public class EnemyDeathBehaviour : MonoBehaviour
    {
        private static float deathDuration;

        public void EnemyDeath(Action action = null)
        {
            StartCoroutine(Destroy(action));
        }

        public void SetConfigurations(float death)
        {
            deathDuration = death;
        }

        private IEnumerator Destroy(Action action)
        {
            yield return new WaitForSeconds(deathDuration);
            action?.Invoke();
        }
    }
}
