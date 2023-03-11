using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField] public float speed;
    [SerializeField] public string leftTag = "LeftPaddle"; // the tag to change to
    [SerializeField] public string rightTag = "RightPaddle"; // the tag to change to
    [SerializeField] private float OriginalSpeed;
    [SerializeField] private Vector2 currentDir;

    private shake Shake;
   

    void Start() {
        // Initial Velocity
       Shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
        GetComponent<Rigidbody>().velocity = Vector2.left * speed;
    }

    void Awake(){
        int selectedSetting = PlayerPrefs.GetInt("BallSpeed");

        if(selectedSetting == 0){
            speed = 6;
        }
        if(selectedSetting == 1){
            speed = 8;
        }
        if(selectedSetting == 2){
            speed = 16;
        }

        OriginalSpeed = speed; 
        
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter(Collision col) {

        Shake.camShake();
        
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft") {
             this.gameObject.tag = leftTag;
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;
            currentDir = dir;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight") {
             this.gameObject.tag = rightTag;
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            currentDir = dir;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }
    }

    public void SpeedShot(Collider collider){
       
        speed = 30;
        GetComponent<Rigidbody>().velocity = currentDir * speed;
        StartCoroutine(WaitForCollision(collider));

    }

     private IEnumerator WaitForCollision(Collider collision)
    {
        // Wait until the next frame
        yield return null;

        // Wait until the collision has ended
        yield return new WaitForFixedUpdate();

        // Revert speed back to the original speed
        speed = OriginalSpeed;
    }

   
   
}
