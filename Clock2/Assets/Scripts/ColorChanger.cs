using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public bool isRed;
    public bool changesColor;

    public Material collidedMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if (changesColor == true)
        {
            GetComponent<Renderer>().material = collidedMaterial; //When this object collides with another object it changes its material
        }
    }
}
