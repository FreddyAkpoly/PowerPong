using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddlePowerUps : MonoBehaviour
{
    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float energyDepletionRate = 10f;
    [SerializeField] private float energyRefillRate = 2f;
    [SerializeField] private float maxScaleMultiplier = 2f;

    [SerializeField] private KeyCode expandKey = KeyCode.E;
    [SerializeField] private KeyCode boostKey = KeyCode.X;
    [SerializeField] private KeyCode shrinkKey = KeyCode.Q;

    [SerializeField] private GameObject rightPaddle;

    [SerializeField] private float energyLevel;
    [SerializeField] private bool isExpanding;
    [SerializeField] private bool isShrinking;
    [SerializeField] private bool isBoostActive;
    [SerializeField] private float expansionAmount = 6;
    [SerializeField] private float shrinkAmount = 3;

    //[SerializeField] EnergyBar energyBar;

    private void Start()
    {
        energyLevel = maxEnergy;
        rightPaddle = GameObject.Find("RacketRight");

        //energyBar.updateFuel(maxEnergy,energyLevel);
    }

    private void Update()
    {
        HandleExpandInput();
        HandleShrinkInput();
        HandleBoostInput();
        HandleReset();
        HandleExpansion();
        HandleShrinking();
        HandleEnergyRefill();
    }

    private void HandleExpandInput()
    {
        if (Input.GetKeyDown(expandKey))
        {
            isExpanding = true;
        }
        if (Input.GetKeyUp(expandKey))
        {
            isExpanding = false;
        }
    }

    private void HandleShrinkInput()
    {
        if (Input.GetKeyDown(shrinkKey))
        {
            isShrinking = true;
        }
        if (Input.GetKeyUp(shrinkKey))
        {
            isShrinking = false;
        }
    }

    private void HandleBoostInput()
    {
        if (Input.GetKeyDown(boostKey) && !isBoostActive)
        {
            isBoostActive = true;
            energyLevel = 0;
            //energyBar.updateFuel(maxEnergy,energyLevel);
        }
        if (Input.GetKeyUp(boostKey))
        {
            isBoostActive = false;
        }
    }

    private void HandleExpansion()
    {
        if (isExpanding && energyLevel > 0f)
        {
            energyLevel -= energyDepletionRate * Time.deltaTime;
           // energyBar.updateFuel(maxEnergy,energyLevel);
            transform.localScale = new Vector3(1, expansionAmount, 0.5f);
        }
        else if (!isExpanding)
        {
            transform.localScale = new Vector3(1, maxScaleMultiplier, 0.5f);
        }
    }

    private void HandleShrinking()
    {
        if (isShrinking && energyLevel > 0f)
        {
            energyLevel -= energyDepletionRate * Time.deltaTime;
           // energyBar.updateFuel(maxEnergy,energyLevel);
            rightPaddle.transform.localScale = new Vector3(1, shrinkAmount, 0.5f);
        }
        else if (!isShrinking)
        {
            rightPaddle.transform.localScale = new Vector3(1, maxScaleMultiplier, 0.5f);
        }
    }

    private void HandleEnergyDepletion()
    {
        if (!isExpanding && !isShrinking)
        {
            energyLevel -= energyDepletionRate * Time.deltaTime;
        }

        if (energyLevel < 0f)
        {
            energyLevel = 0f;
        }
    }

    private void HandleEnergyRefill()
    {
        if (energyLevel < maxEnergy && !isExpanding && !isShrinking)
        {
            energyLevel += energyRefillRate * Time.deltaTime;
            energyLevel = Mathf.Min(energyLevel, maxEnergy);
            //energyBar.updateFuel(maxEnergy,energyLevel);
        }
    }

//     private void OnCollisionEnter(Collision collision)
//     {
//         if (isBoostActive)
//         {
//             BallMovement ballMovement = collision.gameObject.GetComponent<BallMovement>();

//         if (ballMovement != null)
//         {
//             ballMovement.SpeedShot(collision);
//         }
//     }
// }

    private void HandleReset(){
          if (energyLevel < 0f)
        {
            this.transform.localScale = new Vector3(1, 5, 0.5f);
            rightPaddle.transform.localScale = new Vector3(1, 5, 0.5f);
        }
    }
}
