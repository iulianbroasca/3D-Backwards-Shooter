using EnemyModule.Components;
using ObjectPool.BaseScripts;

namespace EnemyModule.Pool
{
    public class EnemyPool : BaseObjectPool<EnemyComponent>
    {
        public void SetEnemyModuleConfigurations(float deathDuration)
        {
            var enemy = GetObjectFromPool(false);
            enemy.SetEnemyConfigurations(deathDuration, this);
            base.AddObjectToPool(enemy);
        }
    }
}
