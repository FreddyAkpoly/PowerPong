using UnityEngine;

public class FirstPaddleMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Awake(){
        int selectedSetting = PlayerPrefs.GetInt("PaddleSpeed");

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
        float moveVertical = 0;
        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
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