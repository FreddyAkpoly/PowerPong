using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalSound : MonoBehaviour
{
   public AudioClip soundClip;
  //  public float volume = 1.0f;

    public AudioSource audioSource;

    private void Start()
    {
       //audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
       // audioSource.volume = volume;
    }

   private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

}
