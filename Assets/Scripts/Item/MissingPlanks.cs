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
        Inventory playerInventory = player.GetComponent<Inventory>();

        if (playerInventory.plankObtained == true)
        {
            playerInventory.plankObtained = false;
            Instantiate(plank, transform.position, transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
