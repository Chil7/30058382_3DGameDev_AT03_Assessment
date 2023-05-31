using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemCollectibles : MonoBehaviour
{
    public ItemType items;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has picked up" + items);

            if (other.GetComponent<Inventory>().PickUp(items) == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
} 

public enum ItemType { exitKey, throneKey, cellKey, jailKey }