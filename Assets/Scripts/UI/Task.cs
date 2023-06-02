using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private Task nextTask;

    public bool isActive = false;

    public Task NextTasks { get { return nextTask; } }

    private void Awake()
    {
        if (isActive == false)
        {
            gameObject.SetActive(false);
        }
    }
}
