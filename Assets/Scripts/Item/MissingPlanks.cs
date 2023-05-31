using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPlanks : MonoBehaviour, IInteraction
{
    private GameObject player;

    [SerializeField] private GameObject plank;

    public void Activate()
    {
        player = GameObject.FindWithTag("Player");

        if (player.GetComponent<Inventory>().planks > 0)
        {
            player.GetComponent<Inventory>().planks--;
            plank.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
