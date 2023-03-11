using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
   public Animator camAnime;
   public void camShake(){
    camAnime.SetTrigger("shake");
   }
}
