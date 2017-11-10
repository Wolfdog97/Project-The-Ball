using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzle : MonoBehaviour {

    public List<ColorChanger> triggers;
    public List<GameObject> wallsToTurnOff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        int numColored = 0;
        foreach (ColorChanger thisColorChanger in triggers)
        {
            if (thisColorChanger.isColored == true)
            {
                numColored++; 
            }
        }

        if (numColored == triggers.Count)
        {
            // turn off the wall
            foreach (GameObject thisObject in wallsToTurnOff)
            {
                thisObject.SetActive(false);
            }
           
        }

	}
}
