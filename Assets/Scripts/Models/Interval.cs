using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Interval<T>
    {
        [SerializeField, Min(0)] private T minimum;
        [SerializeField, Min(0)] private T maximum;

        public (T minimum, T maximum) GetInterval()
        {
            return (minimum, maximum);
        }
    }
}
