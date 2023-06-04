using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IInteraction
{
    private GameObject player;

    public void Activate()
    {
        player = GameObject.FindWithTag("Player");
        Inventory playerInventory = player.GetComponent<Inventory>();

        if (playerInventory.swordObtained == false)
        {
            ErrorManager.errorManager.Popup("Sword");
            FindObjectOfType<AudioManager>().Play("SwordPickUp");
            playerInventory.swordObtained = true;
            Destroy(gameObject);
        }
        
        else
        {
            ErrorManager.errorManager.Error(1, "sword");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            Activate();
        }
    }
}
