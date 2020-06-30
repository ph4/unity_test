using System;
using System.Collections;
using System.Collections.Generic;
using Inputs;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    [SerializeField] private GameObject mainSphere;
    [SerializeField] private VirtualInput input;
    [SerializeField, Range(0f, 10f)] private float height = 1f;
    [SerializeField, Range(0f, 20f)] private float speed = 1f;

    private float _mainRadius;
    private float _radius;
    private Vector3 _velocity;

    // Start is called before the first frame update
    private void Start()
    {
        _mainRadius = mainSphere.transform.lossyScale.x / 2;
        _radius = _mainRadius + height;

        var pos = mainSphere.transform.position;
        pos.y += _radius;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        _velocity = input.InputVector * (speed * Time.deltaTime);

        transform.Rotate(
            _velocity.z / _radius * Mathf.Rad2Deg,
            0,
            -_velocity.x / _radius * Mathf.Rad2Deg,
            Space.Self);

        transform.Translate(_velocity, Space.Self);
    }
}