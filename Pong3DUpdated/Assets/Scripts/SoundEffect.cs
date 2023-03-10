using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundEffect : MonoBehaviour
{
  [SerializeField] public AudioSource src;
  [SerializeField] public AudioClip sfx1;

  public void button1(){
    src.clip = sfx1;
    src.Play();
  }
}
