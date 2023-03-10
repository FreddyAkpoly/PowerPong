using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    
public int  left;
public int right;
    
    public void BeginGame(){
        GameObject characterSelectionObject = GameObject.Find("LeftPaddles");
        CharacterSelection characterSelection = characterSelectionObject.GetComponent<CharacterSelection>();
        left = characterSelection.selectedCharacter;

        CharacterSelectionRight characterSelectionRight = GetComponent<CharacterSelectionRight>();
        right = characterSelectionRight.selectedCharacter;
        PlayerPrefs.SetInt("selectedCharacterLeft",left);
        PlayerPrefs.SetInt("selectedCharacterRight",right);
        NextScence();
   }

   public void NextScence(){
    StartCoroutine(ExampleCoroutine());
   }

    IEnumerator ExampleCoroutine()
    {

    yield return new WaitForSeconds(2);
     SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);

    }

    IEnumerator GoToMainMenu()
    {

    yield return new WaitForSeconds(2);
     SceneManager.LoadScene (0,LoadSceneMode.Single);

    }

     public void GoToMenu(){
    StartCoroutine(GoToMainMenu());
   }
}
