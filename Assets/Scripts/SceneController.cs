using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Starting Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Debug.Log("Restarting Game");
    }
}
