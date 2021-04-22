namespace ObjectPool.Interfaces
{
    public interface IObjectPool<T>
    {
        void RegisterComponent(T component);
        T GetObjectFromPool(bool setActive);
        void AddObjectToPool(T component);
    }
}
