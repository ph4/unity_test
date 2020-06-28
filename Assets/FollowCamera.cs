using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject follow;
    [SerializeField] float speed = 1f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float offsetX = 2f;
    [SerializeField] float offsetY = 1f;

    private Vector3 _velocity;
    private Quaternion _lookRotation;
    // Start is called before the first frame update
    void Start()
    {
        var followTransform = follow.transform;

        var posFollow = follow.transform.position;
        var pos = posFollow;
        pos.y += offsetY;
        pos.x += offsetX;
        transform.position = pos;

        var asin = Mathf.Acos(offsetY / offsetX);
        var rotZ = asin * Mathf.Rad2Deg;
        _lookRotation = Quaternion.AngleAxis(-rotZ, Vector3.right);
        transform.Rotate(Vector3.right, rotZ, Space.Self);
    }

    private void FixedUpdate()
    {
        //transform.SetPositionAndRotation(pos, transform.rotation);
      
        transform.Rotate(transform.right, rotationSpeed * Time.deltaTime, Space.World);
        
        _velocity = Vector3.forward * (speed * Time.deltaTime);
        _velocity = _lookRotation * _velocity;
        
        transform.Translate(_velocity, Space.Self);
    }
}
