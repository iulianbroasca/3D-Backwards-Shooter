using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfiguration", menuName = "Create configuration/Character configuration")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField, Min(0.1f), Tooltip("Movement speed for the left and right.")] 
        private float lateralSpeed;

        public float GetLateralSpeed => lateralSpeed;
    }
}
