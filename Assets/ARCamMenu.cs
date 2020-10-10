using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARCamMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        Debug.Log("Goes Back to Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
