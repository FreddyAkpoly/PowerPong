using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool isPaused = false;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPaused)
        {
            Resume();
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.R) && isPaused)
        {
            Resume();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }

   

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        ShowPauseMenu();
    }

    void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        HidePauseMenu();
    }

    void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
    }

    void HidePauseMenu()
    {
        PauseMenu.SetActive(false);
    }
}
