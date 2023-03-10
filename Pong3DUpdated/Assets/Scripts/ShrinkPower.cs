using UnityEngine;
using System.Collections;

public class ShrinkPower : MonoBehaviour
{
    public GameObject LeftPaddle; // drag the object you want to expand in the inspector
    public GameObject RightPaddle; 
    public float shrinkAmount = 1; // set the amount you want to expand in the inspector
    public Vector3 farAwayPosition; // set the position where you want to move the object after first collision
    public float expansionDuration = 3f; // set the duration of expansion in seconds
    public float returnDuration; // set the duration of returning to original position in seconds
    private Vector3 originalPosition; // variable to store the original position of the object

    private bool hasCollided = false; // variable to check if the collision has already occurred
private bool hasUpdated = false;
private void Awake(){
        int selectedSetting = PlayerPrefs.GetInt("Powerups");
        int spawnSpeed =  PlayerPrefs.GetInt("SpawnSpeed");
        if(selectedSetting == 1){
            gameObject.SetActive(false);
        }

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
    private void Update()
    {
        if (!hasUpdated)
    {
        LeftPaddle =GameObject.Find("RacketLeft");
        RightPaddle =GameObject.Find("RacketRight");
       hasUpdated = true;
    }
    }
     private void Start()
    {
        originalPosition = this.transform.position;
     
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the object that entered the trigger has a specific tag
        if (other.gameObject.CompareTag("LeftPaddle"))
        {
            if (!hasCollided)
            {
                // increase the scale of the objectToExpand by the expansionAmount
                RightPaddle.transform.localScale -= new Vector3(0, shrinkAmount, 0);
                // move the objectToExpand to the far away position
                this.transform.position = farAwayPosition;
                // Start a coroutine to decrease the scale of the object after expansionDuration
                StartCoroutine(RevertExpansionRight(expansionDuration));
                StartCoroutine(ReturnToOriginalPosition(returnDuration));
                hasCollided = true;
            }
        }
        if (other.gameObject.CompareTag("RightPaddle"))
        {
            if (!hasCollided)
            {
                // increase the scale of the objectToExpand by the expansionAmount
                LeftPaddle.transform.localScale -= new Vector3(0, shrinkAmount, 0);
                // move the objectToExpand to the far away position
                this.transform.position = farAwayPosition;
                // Start a coroutine to decrease the scale of the object after expansionDuration
                StartCoroutine(RevertExpansionLeft(expansionDuration));
                StartCoroutine(ReturnToOriginalPosition(returnDuration));
                hasCollided = true;
            }
        }
    }
    // coroutine to decrease the scale of the object after expansionDuration
    private IEnumerator RevertExpansionRight(float duration)
    {
        yield return new WaitForSeconds(duration);
        RightPaddle.transform.localScale += new Vector3(0, shrinkAmount, 0);
    }

    private IEnumerator RevertExpansionLeft(float duration)
    {
        yield return new WaitForSeconds(duration);
        LeftPaddle.transform.localScale += new Vector3(0, shrinkAmount, 0);
    }

    private IEnumerator ReturnToOriginalPosition(float duration)
    {
        yield return new WaitForSeconds(duration);
         hasCollided = false;
        this.transform.position = originalPosition;

    }
}
