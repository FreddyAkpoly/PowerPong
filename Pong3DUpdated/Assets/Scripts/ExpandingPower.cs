using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExpandingPower : MonoBehaviour
{
    public GameObject LeftPaddle; // drag the object you want to expand in the inspector
    public GameObject RightPaddle; 
    public float shrinkAmount = 1; // set the amount you want to expand in the inspector
    public Vector3 farAwayPosition; // set the position where you want to move the object after first collision
    public float shrinkDuration = 3f; // set the duration of expansion in seconds
    public float returnDuration = 5f; // set the duration of returning to original position in seconds
    private Vector3 originalPosition; // variable to store the original position of the object
private bool hasUpdated = false;
    private bool hasCollided = false; // variable to check if the collision has already occurred



    private void Awake(){
       
        int selectedSetting = PlayerPrefs.GetInt("Powerups");

        if(selectedSetting == 1){
            gameObject.SetActive(false);
        }

        int spawnSpeed =  PlayerPrefs.GetInt("SpawnSpeed");

        if(spawnSpeed == 0){
            returnDuration = 7f;
        }
        if(spawnSpeed == 1){
            returnDuration = 5f;
        }
        if(spawnSpeed == 2){
            returnDuration = 3f;
        }
    }
    private void Start()
    {
       
       
        // store the original position of the object
        originalPosition = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the object that entered the trigger has a specific tag
        if (other.gameObject.CompareTag("LeftPaddle"))
        {
            if (!hasCollided)
            {
                // increase the scale of the objectToExpand by the shrinkAmount
                LeftPaddle.transform.localScale += new Vector3(0, shrinkAmount, 0);
                // move the objectToExpand to the far away position
                this.transform.position = farAwayPosition;
                // Start a coroutine to decrease the scale of the object after shrinkDuration
                StartCoroutine(RevertExpansionLeft(shrinkDuration));
                StartCoroutine(ReturnToOriginalPosition(returnDuration));
                hasCollided = true;
            }
        }
        if (other.gameObject.CompareTag("RightPaddle"))
        {
            if (!hasCollided)
            {
                // increase the scale of the objectToExpand by the shrinkAmount
                RightPaddle.transform.localScale += new Vector3(0, shrinkAmount, 0);
                // move the objectToExpand to the far away position
                this.transform.position = farAwayPosition;
                // Start a coroutine to decrease the scale of the object after shrinkDuration
                StartCoroutine(RevertExpansionRight(shrinkDuration));
                StartCoroutine(ReturnToOriginalPosition(returnDuration));
                hasCollided = true;
            }
        }
    }

     private void Update()
    {
        if (!hasUpdated)
    {
        LeftPaddle =GameObject.Find("RacketLeft");
        RightPaddle =GameObject.Find("RacketRight");
       hasUpdated = true;
    }
    }
    // coroutine to decrease the scale of the object after shrinkDuration
    private IEnumerator RevertExpansionRight(float duration)
    {
        yield return new WaitForSeconds(duration);
        RightPaddle.transform.localScale -= new Vector3(0, shrinkAmount, 0);
    }

    private IEnumerator RevertExpansionLeft(float duration)
    {
        yield return new WaitForSeconds(duration);
        LeftPaddle.transform.localScale -= new Vector3(0, shrinkAmount, 0);
    }

    private IEnumerator ReturnToOriginalPosition(float duration)
    {
        yield return new WaitForSeconds(duration);
         hasCollided = false;
        this.transform.position = originalPosition;

    }
    
}
