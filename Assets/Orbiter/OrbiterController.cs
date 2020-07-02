using Inputs;
using UnityEngine;

namespace Orbiter
{
    public class OrbiterController : OrbiterControllerBase
    {
        private Vector3 _velocity;

        public OrbiterController(VirtualInput input, Transform transform, OrbiterConfig config) 
            : base(input, transform, config)
        {
        }
        public override void Tick()
        {
            _velocity = Input.InputVector * (OrbiterConfig.Speed * Time.deltaTime);

            Transform.Rotate(
                _velocity.z / OrbiterConfig.Radius * Mathf.Rad2Deg,
                0,
                -_velocity.x / OrbiterConfig.Radius * Mathf.Rad2Deg,
                Space.Self);

            Transform.Translate(_velocity, Space.Self);
        }

    }
}