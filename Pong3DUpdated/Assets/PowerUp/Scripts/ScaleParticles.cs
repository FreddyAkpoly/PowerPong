using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour {
    void Update () {
        ParticleSystem.MainModule mainModule = GetComponent<ParticleSystem>().main;
        mainModule.startSize = transform.lossyScale.magnitude;
    }
}
