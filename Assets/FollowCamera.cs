using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject follow;
    [SerializeField] float innerRadius = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float speedFactor = 1f;
    [SerializeField] float offsetX = 2f;
    [SerializeField] float offsetY = 1f;

    private float _speed;
    private Vector3 _velocity;
    private Quaternion _lookRotation;
    // Start is called before the first frame update
    void Start()
    {
        var pos = follow.transform.position;
        pos.y += offsetY;
        pos.x += offsetX;
        transform.position = pos;

        _speed = (innerRadius + offsetY) * (rotationSpeed * Mathf.Deg2Rad) * speedFactor;

        var rotZ = Mathf.Atan2(offsetY, offsetX) * Mathf.Rad2Deg;
        _lookRotation = Quaternion.AngleAxis(-rotZ, Vector3.right);
        transform.Rotate(Vector3.right, rotZ, Space.Self);
    }

    private void Update()
    {
        transform.Rotate(transform.right, rotationSpeed * Time.deltaTime, Space.World);
        
        _velocity = Vector3.forward * (_speed * Time.deltaTime);
        _velocity = _lookRotation * _velocity;
        
        transform.Translate(_velocity, Space.Self);
    }
}