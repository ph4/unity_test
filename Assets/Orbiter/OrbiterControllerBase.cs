using Inputs;
using UnityEngine;

namespace Orbiter
{
    public abstract class OrbiterControllerBase
    {
        protected VirtualInput Input;
        protected Transform Transform;
        protected OrbiterConfig OrbiterConfig;

        protected OrbiterControllerBase(VirtualInput input, Transform transform, OrbiterConfig config)
        {
            Input = input;
            Transform = transform;
            OrbiterConfig = config;
        }

        public abstract void Tick();
    }
}