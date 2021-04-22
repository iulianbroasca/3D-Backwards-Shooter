using BulletModule.Components;
using ObjectPool.BaseScripts;

namespace BulletModule.Pool
{
    public class BulletPool : BaseObjectPool<BulletComponent>
    {
        public void SetBulletConfigurations(float speed, float bulletLifeDuration)
        {
            var bullet = GetObjectFromPool(false);
            bullet.SetBulletConfigurations(speed, bulletLifeDuration, this);
            base.AddObjectToPool(bullet);
        }
    }
}
