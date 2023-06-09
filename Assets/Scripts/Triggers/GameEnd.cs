using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject Button;

    public delegate void GameWinDelegate();
    public event GameWinDelegate GameWinEvent = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameWinEvent.Invoke();
            EventSystem.current.SetSelectedGameObject(Button);
        }
    }
}
