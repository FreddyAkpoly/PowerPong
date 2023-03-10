using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
   public GameObject[] characterPrefabs;
   public Transform spawnPoint;

   void Start()
   {
    int selectedCharacter = PlayerPrefs.GetInt("selectedCharacterLeft");
    GameObject prefab = characterPrefabs[selectedCharacter];
    GameObject clone = Instantiate(prefab,spawnPoint.position, Quaternion.identity);
    clone.gameObject.name = "RacketLeft";
   }
}
