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
            FindObjectOfType<AudioManager>().Play("PickUpKey");

            if (other.GetComponent<Inventory>().PickUp(items) == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
} 

public enum ItemType { exitKey1, exitKey2, throneKey, cellKey, jailKey }