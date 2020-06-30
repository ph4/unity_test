using UnityEngine;

namespace Inputs
{
    class FakeInput : VirtualInput
    {
        public override Vector3 InputVector { get; }

        public FakeInput(Vector3 vec)
        {
            InputVector = vec;
        }
    }
}