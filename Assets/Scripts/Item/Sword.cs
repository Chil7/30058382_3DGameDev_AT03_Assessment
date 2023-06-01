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

        FindObjectOfType<AudioManager>().Play("SwordPickUp");
        if (playerInventory.swordObtained == false)
        {
            playerInventory.swordObtained = true;
            this.gameObject.SetActive(false);
        }
        
        else
        {
            //Tell player can only equip 1 sword at a time
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
