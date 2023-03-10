using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterRight : MonoBehaviour
{
    public GameObject[] characterPrefabs;
   public Transform spawnPoint;

   void Start()
   {
    int selectedCharacter = PlayerPrefs.GetInt("selectedCharacterRight");
    GameObject prefab = characterPrefabs[selectedCharacter];
    GameObject clone = Instantiate(prefab,spawnPoint.position, Quaternion.identity);
    clone.gameObject.name = "RacketRight";
   }
}
