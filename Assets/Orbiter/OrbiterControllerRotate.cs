using Inputs;
using UnityEngine;

namespace Orbiter
{
    public class OrbiterControllerRotate : OrbiterControllerBase
    {
        private float _speed;

        public OrbiterControllerRotate(VirtualInput input, Transform transform, OrbiterConfig config) : base(input, transform, config)
        {
        }

        public override void Tick()
        {
            _speed = Input.InputVector.z * (OrbiterConfig.Speed * Time.deltaTime);

            Transform.Rotate(
                _speed / OrbiterConfig.Radius * Mathf.Rad2Deg,
                Input.InputVector.x * OrbiterConfig.TurnSpeed * Time.deltaTime,
                0,
                Space.Self);

            Transform.Translate(0, 0, _speed ,Space.Self);
        }
    }
}