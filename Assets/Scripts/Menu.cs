using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(2);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}

