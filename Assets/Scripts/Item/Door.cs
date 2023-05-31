using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    private GameObject player;

    public bool locked = true;
    public ItemType item1;
    public ItemType item2;


    public void Activate()
    {
        player = GameObject.FindWithTag("Player");
        Inventory playerInventory = player.GetComponent<Inventory>();
        
        if (playerInventory.CheckItems(item1) == true && playerInventory.CheckItems(item2) == true)
        {
            Debug.Log("Unlock");
            locked = false;
            //remove this later and replace for an animation instead. this is just a test
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Lock");
        }
    }
}
