using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfiguration", menuName = "Create configuration/Character configuration")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private float lateralSpeed;

        public float GetLateralSpeed => lateralSpeed;
    }
}
