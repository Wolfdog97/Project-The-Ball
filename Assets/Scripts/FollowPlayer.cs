﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField] private Transform target;


    public float rotSpeedX = 1.5f;
    public float rotSpeedY = .5f;

    private float _rotY;
    private float _rotX;

    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;

        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}

