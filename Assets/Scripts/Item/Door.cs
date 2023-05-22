using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    private GameObject player;

    public bool locked = true;
    public ItemType item;


    public void Activate()
    {
        player = GameObject.FindWithTag("Player");
        
        if (player.GetComponent<Inventory>().CheckItems(item) == true)
        {
            Debug.Log("Unlock");
            locked = false;
        }
        else
        {
            Debug.Log("Lock");
        }
    }
}
