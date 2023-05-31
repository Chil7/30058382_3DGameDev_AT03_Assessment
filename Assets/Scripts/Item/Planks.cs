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
                //Add 1 plank to player's inventory
                playerInventory.plankObtained = true;
                gameObject.SetActive(false);
            }
            else
            {
                //Tell that player can only pick up 1 plank
                Debug.Log("Can pick 1");
            }
        }
    }
}
