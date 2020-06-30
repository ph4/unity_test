using UnityEngine;

namespace Inputs
{
    public abstract class VirtualInput : MonoBehaviour
    {
        public abstract Vector3 InputVector { get; }
    }
}