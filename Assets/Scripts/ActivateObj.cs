using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObj : MonoBehaviour {

    public List<ColorChanger> triggers;
    public List<GameObject> objectsToTurnOn;

	// Update is called once per frame
	void Update () {

        int numColored = 0;

        foreach (ColorChanger thisColorChanger in triggers)
        {
            if(thisColorChanger.isColored == true)
            {
                // Everytime an object in the list changes color numcolored goes up by one.
                numColored++;
            }
        }
        
        if(numColored == triggers.Count)
        {
            //Turn on the wall
            foreach (GameObject thisObject in objectsToTurnOn)
            {
                thisObject.SetActive(true);
            }
        }
	}
}
