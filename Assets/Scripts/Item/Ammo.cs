using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");

        if (other.tag == "Player")
        {
            if (player.GetComponent<Inventory>().shotCount <= 0) 
            {
                Debug.Log("Picked up Taser");
                player.GetComponent<Inventory>().LoadGun(1);
                gameObject.SetActive(false);
            }
            Debug.Log("Can only Pick up one ammo");
            
        }
    }
}
