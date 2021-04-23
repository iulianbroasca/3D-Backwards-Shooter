using InputModule.Interfaces;
using UnityEngine;

namespace InputModule.Models
{
    public class MobileInput : IInput
    {
        public Vector3 GetInput()
        {
            return Input.GetTouch(0).position;
        }
    }
}
