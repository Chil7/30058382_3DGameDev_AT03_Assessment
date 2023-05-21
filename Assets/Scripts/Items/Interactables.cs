using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Interactables : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    public static Interactables interactablesInstance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Door>().ActivateInteractable += Activate;
    }

    public abstract class ItemActiveState : IState
    {
        protected Interactables instance;

        public ItemActiveState(Interactables _instance)
        {
            instance = _instance;
        }

        public void OnActive()
        {
            
        }
    }

    public void Activate()
    {
        
    }
}
