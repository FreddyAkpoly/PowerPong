using System.Collections;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void ResetToOriginalPosition()
    {
        // Start the coroutine to wait 2 seconds before resetting the object
        StartCoroutine(WaitAndReset(1f));
    }

    private IEnumerator WaitAndReset(float delaySeconds)
    {
        // Wait for the specified delay before resetting the object
        yield return new WaitForSeconds(delaySeconds);

        // Reset the object to its original position
        transform.position = originalPosition;
    }
}
