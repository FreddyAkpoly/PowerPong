using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text countdownText;
    private float fixedDeltaTime;

private void Start()
{
    
    fixedDeltaTime = Time.fixedDeltaTime;
    StartCoroutine(CountDown());
}

IEnumerator CountDown()
{
    Time.timeScale = 0;
    Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;

    countdownText.text = "3";
    yield return new WaitForSecondsRealtime(1f);
    countdownText.text = "2";
    yield return new WaitForSecondsRealtime(1f);
    countdownText.text = "1";
    yield return new WaitForSecondsRealtime(1f);
    countdownText.text = "Go!";
    yield return new WaitForSecondsRealtime(1f);
    countdownText.text = "";
   
    Time.timeScale = 1;
    Time.fixedDeltaTime = fixedDeltaTime;
}

}
