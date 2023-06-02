using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private Task nextTask;

    public Task NextTasks { get { return nextTask; } }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
