using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPlanks : MonoBehaviour, IInteraction
{
    private GameObject player;

    [SerializeField] private GameObject plank;

    public void Activate()
    {
        player = GameObject.FindWithTag("Player");
        Inventory playerInventory = player.GetComponent<Inventory>();

        if (playerInventory.plankObtained == true)
        {
            FindObjectOfType<AudioManager>().Play("PlacePlank");
            playerInventory.plankObtained = false;
            Instantiate(plank, transform.position, transform.rotation);
            this.gameObject.SetActive(false);
        }
        else
        {
            ErrorManager.errorManager.Error(3, null);
        }
    }
}
