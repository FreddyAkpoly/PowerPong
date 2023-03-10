using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] private Image fuelSprite;
    
    public void updateFuel(float maxEnergy, float energyLevel){

        fuelSprite.fillAmount = energyLevel/maxEnergy;

    }

}
