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
            ErrorManager.errorManager.Popup(items.ToString());
            FindObjectOfType<AudioManager>().Play("PickUpKey");

            if (other.GetComponent<Inventory>().PickUp(items) == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
} 

public enum ItemType { ExitKey, BalconyKey, ThroneKey, CellKey, JailKey }