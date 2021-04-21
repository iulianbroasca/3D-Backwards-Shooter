using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Interval<T>
    {
        [SerializeField] private T minimum;
        [SerializeField] private T maximum;

        public (T minimum, T maximum) GetInterval()
        {
            return (minimum, maximum);
        }
    }
}
