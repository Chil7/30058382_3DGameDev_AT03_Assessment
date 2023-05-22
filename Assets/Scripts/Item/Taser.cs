using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");

        if (other.tag == "Player")
        {
            Debug.Log("Picked up Taser");
            player.GetComponent<Inventory>().LoadTaser(1);
            gameObject.SetActive(false);
        }
    }
}
