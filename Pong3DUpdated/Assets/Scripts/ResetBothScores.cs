using UnityEngine;

public class ResetBothScores : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;

    public void ResetBoth()
    {
        Score score1 = gameObject1.GetComponent<Score>();
        Score score2 = gameObject2.GetComponent<Score>();

        score1.clear();
        score2.clear();
    }
}
