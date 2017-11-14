using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Game Starter")
        {
            SceneManager.LoadScene("The Pillers");
           // Debug.Log("Changing scene");
        }
       
    }

}
