using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotators : MonoBehaviour
{
    public bool isRotating;

    // Update is called once per frame
    void Update()
    {
        if (isRotating == true)
        {
            transform.Rotate(new Vector3(15, 30, 35) * Time.deltaTime);
        }
    }
}
