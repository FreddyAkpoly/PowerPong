using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundCounter : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    private int roundNumber = 1;

    void Start()
    {
        UpdateRoundText();
    }

    public void UpdateRoundText()
    {
        roundText.text = "Round " + roundNumber.ToString();
    }

    public void IncrementRound()
    {
        roundNumber++;
        UpdateRoundText();
    }
}
