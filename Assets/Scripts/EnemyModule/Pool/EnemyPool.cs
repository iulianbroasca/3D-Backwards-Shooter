using System;
using EnemyModule.Components;
using ObjectPool.BaseScripts;

namespace EnemyModule.Pool
{
    public class EnemyPool : BaseObjectPool<EnemyComponent>
    {
        public void SetEnemyModuleConfigurations(float deathDuration, Action shotDownByBullet, Action shotDownByObstacle)
        {
            var enemy = GetObjectFromPool(false);
            enemy.SetEnemyConfigurations(deathDuration, this, shotDownByBullet, shotDownByObstacle);
            base.AddObjectToPool(enemy);
        }
    }
}
