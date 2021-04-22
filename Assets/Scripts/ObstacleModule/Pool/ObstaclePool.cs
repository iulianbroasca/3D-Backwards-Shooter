using ObjectPool.BaseScripts;
using ObstacleModule.Components;

namespace ObstacleModule.Pool
{
    public class ObstaclePool : BaseObjectPool<ObstacleComponent>
    {
        public void SetObstacleModuleConfigurations(float obstacleLifeDuration)
        {
            var obstacle = GetObjectFromPool(false);
            obstacle.SetObstacleConfigurations(this, obstacleLifeDuration);
            base.AddObjectToPool(obstacle);
        }
    }
}
