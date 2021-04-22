using System.Collections.Generic;
using ObjectPool.Interfaces;
using UnityEngine;

namespace ObjectPool.BaseScripts
{
    public abstract class BaseObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour
    {
        protected readonly Queue<T> pool = new Queue<T>();
        protected T component;

        public virtual void RegisterComponent(T component)
        {
            this.component = component;
        }

        public virtual T GetObjectFromPool(bool setActive = true)
        {
            LazyInstantiation();
            var element = pool.Dequeue();
            element.gameObject.SetActive(setActive);
            return element;
        }

        public virtual void AddObjectToPool(T component)
        {
            EnqueueComponent(component);
        }

        private void LazyInstantiation()
        {
            if (pool.Count > 0)
                return;

            EnqueueComponent(Instantiate(component));
        }

        private void EnqueueComponent(T component)
        {
            component.gameObject.SetActive(false);
            pool.Enqueue(component);
        }
    }
}
