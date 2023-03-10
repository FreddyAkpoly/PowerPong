using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip soundClip;
  //  public float volume = 1.0f;

    public AudioSource audioSource;

    private void Start()
    {
       // audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
       // audioSource.volume = volume;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }

}
