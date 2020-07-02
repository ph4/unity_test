using Inputs;
using UnityEngine;

namespace Orbiter
{
    [CreateAssetMenu(menuName = "Orbiter/Settings", fileName = "OrbiterData")]
    public class OrbiterConfig : ScriptableObject
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float radius = 6f;
        [SerializeField] private float turnSpeed = 10f;

        public float Speed => speed;
        public float Radius => radius;
        public float TurnSpeed => turnSpeed;
    }
}