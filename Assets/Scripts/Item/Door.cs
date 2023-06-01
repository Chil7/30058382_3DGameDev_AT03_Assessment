using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door : MonoBehaviour, IInteraction
{
    private GameObject player;
    private Animator animator;
    [SerializeField] private string doorSound;

    public bool locked = true;
    public ItemType item1;
    public ItemType item2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        player = GameObject.FindWithTag("Player");
        Inventory playerInventory = player.GetComponent<Inventory>();
        
        if (playerInventory.CheckItems(item1) == true && playerInventory.CheckItems(item2) == true)
        {
            
            locked = false;
            FindObjectOfType<AudioManager>().Play(doorSound);
            animator.SetTrigger("Unlock");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("DoorLock");
            Debug.Log("Lock");
        }
    }
}
