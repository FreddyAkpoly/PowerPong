using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Gamemusic");
        DontDestroyOnLoad(this.gameObject);
    }
}
