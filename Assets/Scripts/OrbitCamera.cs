using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
    [SerializeField] private Transform target;


    public float rotSpeedX = 1.5f;
    public float rotSpeedY = .5f;

    private float _rotY;
    private float _rotX;

    private Vector3 _offset;

	// Use this for initialization
	void Start () {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;

        _offset = target.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float yIncrement = Input.GetAxis("Mouse X") * rotSpeedX * 3;
        float xIncrement = Input.GetAxis("Mouse Y") * rotSpeedY * 3;
        _rotY += yIncrement;
        _rotX += xIncrement;


        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        Vector3 nextPosition = target.position - (rotation * _offset);
        if (nextPosition.y < target.transform.position.y)
        {
            _rotX -= xIncrement;
            rotation = Quaternion.Euler(_rotX, _rotY, 0);
            nextPosition = target.position - (rotation * _offset);
        }
        float yCap = Mathf.Max(nextPosition.y, target.transform.position.y);
        transform.position = new Vector3(nextPosition.x, yCap, nextPosition.z);
        transform.LookAt(target);
	}
}
