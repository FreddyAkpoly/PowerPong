using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedShot : MonoBehaviour
{
    public float speedBoost = 2.0f;
    private Rigidbody otherRB2D;
    private float originalSpeed;
    private Vector3 originalPosition;
    public float returnDuration = 5f;
    public Vector3 farAwayPosition;
     private void Start()
    {
        originalPosition = this.transform.position;
    }

    private void Awake(){
        int selectedSetting = PlayerPrefs.GetInt("Powerups");

        if(selectedSetting == 1){
            gameObject.SetActive(false);
        }

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

    void OnTriggerEnter(Collider collider)
{
    if (collider != null)
    {
        BallMovement ballMovement = collider.gameObject.GetComponent<BallMovement>();
        if (ballMovement != null)
        {
            ballMovement.SpeedShot(collider);
             this.transform.position = farAwayPosition;
            StartCoroutine(ReturnToOriginalPosition(returnDuration));
        }
    }
}

    private IEnumerator ReturnToOriginalPosition(float duration)
    {
        yield return new WaitForSeconds(duration);
        this.transform.position = originalPosition;

    }



}
