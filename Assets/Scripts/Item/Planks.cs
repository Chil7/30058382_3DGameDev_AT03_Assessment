using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planks : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");
        Inventory playerInventory = player.GetComponent<Inventory>();

        if (other.tag == "Player")
        {
            if (playerInventory.plankObtained == false)
            {
                ErrorManager.errorManager.Popup("Plank");
                FindObjectOfType<AudioManager>().Play("PickUpPlank");
                playerInventory.plankObtained = true;
                Destroy(gameObject);
            }
            else
            {
                ErrorManager.errorManager.Error(1, "plank");
            }
        }
    }
}
