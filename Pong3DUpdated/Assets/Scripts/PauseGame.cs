using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu; 
    private bool isPaused = false;
    void Start(){
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