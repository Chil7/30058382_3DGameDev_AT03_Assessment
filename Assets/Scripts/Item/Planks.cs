using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planks : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");

        if (other.tag == "Player")
        {
            player.GetComponent<Inventory>().planks += 1;
            gameObject.SetActive(false);
        }
    }
}
