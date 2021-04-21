using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfiguration", menuName = "Create configuration/Character configuration")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private float speedBackward;
        [SerializeField] private float waitingTimeNextShot;

        public float SpeedBackward => speedBackward;

        public float WaitingTimeNextShot => waitingTimeNextShot;
    }
}
