using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class hitEffect : MonoBehaviour
{
    public Transform particlesPool;
    private GameObject[] hitEffects;
	public int hitIndex;

void Start()
		{
			hitIndex = 2;
			
			hitEffects = new GameObject[particlesPool.childCount];
			
			for(int i = 0; i < particlesPool.childCount; i++)
			{
				hitEffects[i] = particlesPool.GetChild(i).gameObject;
			}
			
			
		}


         void OnCollisionEnter(Collision col) {
			{
					
					
						GameObject newHits = SpawnHit();
						newHits.transform.position = this.transform.position;
					
				}
			
    }


    private GameObject SpawnHit()
		{
			GameObject spawnedHit = Instantiate(hitEffects[hitIndex]);
			return spawnedHit;
		}
}
