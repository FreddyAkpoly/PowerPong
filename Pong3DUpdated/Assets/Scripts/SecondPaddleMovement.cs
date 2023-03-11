using UnityEngine;

public class SecondPaddleMovement : MonoBehaviour
{
  
    public float speed = 10.0f;
    public float smoothTime = 0.1f;
    private Rigidbody rb;
    private GameObject ball;
    private float targetY;  
    private int selectedType;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
         ball = GameObject.Find("Ball");
     
    }
    void Awake(){
        int selectedSetting = PlayerPrefs.GetInt("PaddleSpeed");
        selectedType = PlayerPrefs.GetInt("GameType");

        if(selectedSetting == 0){
            speed = 6f;
        }
        if(selectedSetting == 1){
            speed = 10f;
        }
        if(selectedSetting == 2){
            speed = 14f;
        }
    }
    

    void Update()
    {
        if(selectedType ==1 ){
                 float moveVertical = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVertical = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVertical = -1;
        }
        Vector2 movement = new Vector2(0.0f, moveVertical);

        if (moveVertical != 0)
        {
            rb.velocity = new Vector2(0, moveVertical * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        }
       
    }

    
    void LateUpdate()
    {
        if(selectedType ==0 ){
          if (ball != null)
        {
            // Set the target Y position based on the ball's position
            targetY = Mathf.Lerp(transform.position.y, ball.transform.position.y, smoothTime);

            // Move the paddle towards the target Y position
            rb.velocity = new Vector3(0, (targetY - transform.position.y) * speed, 0);
        }
    }
    }
}
