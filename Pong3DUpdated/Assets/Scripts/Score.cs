using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Score : MonoBehaviour
{
    //public TMP_Text scoreText;
    private int score = 0;
    public ResetObject resetObject;
    public int targetScore = 7;
    public int targetRounds = 3;
    public int roundsWon = 0;
    public Image[] ScoreCount; // array of Image components to change color
    public Image[] roundCount; // array of Image components to change color
    private int colorIndex = 0; // index of current Image component to change color
    private int roundIndex = 0; // index of current Image component to change color
    public GameObject resetManager;

    public Transform particlesPool;
    private GameObject[] hitEffects;
	public int hitIndex;

    public RoundCounter roundCounter; 



    void Start()
		{

			hitEffects = new GameObject[particlesPool.childCount];
			
			for(int i = 0; i < particlesPool.childCount; i++)
			{
				hitEffects[i] = particlesPool.GetChild(i).gameObject;
			}

            roundCounter = FindObjectOfType<RoundCounter>();
			
			
		}



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ball")){
        score++;
       // scoreText.text = "Score: " + score;
        Debug.Log("Scored");

        GameObject newHits = SpawnHit();
		newHits.transform.position = other.transform.position;


        resetObject.ResetToOriginalPosition();

        // Change color of Image component
        if (colorIndex < ScoreCount.Length && score >= colorIndex + 1)
        {
            ScoreCount[colorIndex].color = Color.green;
            colorIndex++;
        }

        if (score >= targetScore)
        {
            roundsWon++;
            roundCounter.IncrementRound();

            if (roundIndex < roundCount.Length && roundsWon >= roundIndex + 1)
        {
            roundCount[roundIndex].color = Color.green;
            roundIndex++;
        }

            // Reset color of colorObjects

             ResetBothScores clearer = resetManager.GetComponent<ResetBothScores>();
                   clearer.ResetBoth();


            score = 0; 
            colorIndex = 0;
            if (roundsWon >= targetRounds)
            {
                
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    }

    public void clear(){

         for (int i = 0; i < ScoreCount.Length; i++)
                    {
                        ScoreCount[i].color = new Color(0.6084906f,0.8113208f,0.6246892f) ;
                    }

    }

     private GameObject SpawnHit()
		{
			GameObject spawnedHit = Instantiate(hitEffects[hitIndex]);
			return spawnedHit;
		}
}
