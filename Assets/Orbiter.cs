using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    [SerializeField] GameObject mainSphere;
    [SerializeField, Range(0f, 10f)] float height = 1f;
    [SerializeField, Range(0f, 20f)] float angularSpeed = 1f;

    private float _mainRadius;
    private float _radius;
    private Vector3 _position;
    
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
        _radius = _mainRadius + height;
        transform.RotateAround(
            mainSphere.transform.position,
            mainSphere.transform.forward,
            angularSpeed * Time.deltaTime);
    }
}
