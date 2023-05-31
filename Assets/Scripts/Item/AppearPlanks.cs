using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPlanks : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupablePlanks;

    private void Start()
    {
        foreach (GameObject planks in pickupablePlanks)
        {
            planks.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject planks in pickupablePlanks)
            {
                planks.SetActive(true);
            }
           
        }
    }
}
