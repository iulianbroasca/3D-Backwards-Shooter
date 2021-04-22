using GameConfigurationModule.Managers;
using ScriptableObjects;
using UnityEngine;

namespace RoadModule.Components
{
    public class RoadComponent : MonoBehaviour
    {
        private void Awake()
        {
            var scale = transform.localScale;
            scale.x = ConfigurationManager.Instance.GetConfiguration<GameConfiguration>().RoadWidth;
            transform.localScale = scale;
        }
    }
}
