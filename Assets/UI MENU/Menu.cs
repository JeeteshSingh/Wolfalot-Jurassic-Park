using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAR()
    {
        Debug.Log("New Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Debug.Log("Has Quit the Game");
        Application.Quit();
    }
}
