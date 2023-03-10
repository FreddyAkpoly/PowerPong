using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameSettings : MonoBehaviour
{
   
    public TMP_Text optionText;
    public int currentOption = 0;
    public string[] options;
    public string pref = ""; 

    private void Start()
    {
        optionText.text = options[currentOption];
        PlayerPrefs.SetInt(pref,currentOption);
    }

    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Length)
        {
            currentOption = 0;
        }
        optionText.text = options[currentOption];
        PlayerPrefs.SetInt(pref,currentOption);
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption < 0)
        {
            currentOption = options.Length - 1;
        }
        optionText.text = options[currentOption];
        PlayerPrefs.SetInt(pref,currentOption);
    }

}
