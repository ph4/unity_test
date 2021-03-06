﻿using System;
using Inputs;
using UnityEngine;

namespace Orbiter
{
    public class Orbiter : MonoBehaviour
    {
        //[SerializeField] private GameObject mainSphere;
        
        [SerializeField] private GameObject mainSphere;
        [SerializeField] private OrbiterConfig orbiterConfig;
        [SerializeField] private VirtualInput vInput;

        private OrbiterControllerBase _orbiterController;
        private float _mainRadius;

        private void Awake()
        {
            var trans = transform;
            _orbiterController = orbiterConfig.Rotate ?
                 new OrbiterControllerRotate(vInput, trans, orbiterConfig) : 
                (OrbiterControllerBase) new OrbiterController(vInput, trans, orbiterConfig);
        }

        // Start is called before the first frame update
        private void Start()
        {
            var pos = mainSphere.transform.position;
            pos.y += orbiterConfig.Radius;
            transform.position = pos;
        }

        private void FixedUpdate()
        {
            _orbiterController.Tick();
        }
    }
}