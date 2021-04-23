using InputModule.Interfaces;
using UnityEngine;

namespace InputModule.Models
{
    public class MouseInput : IInput
    {
        public Vector3 GetInput()
        {
            return Input.mousePosition;
        }
    }
}
