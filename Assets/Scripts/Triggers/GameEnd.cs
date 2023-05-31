using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public delegate void GameWinDelegate();
    public event GameWinDelegate GameWinEvent = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameWinEvent.Invoke();
        }
    }
}
