using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private Task[] tasks;
    [SerializeField] private Task currTask;
    private Task previousTask;

    public Task[] Tasks { get { return tasks; } }

    private void Start()
    { 
        if (currTask.gameObject.activeSelf == false)
        {
            currTask.gameObject.SetActive(true);
        }
    }


    public void UpdateTask()
    {
        previousTask = currTask;
        currTask = currTask.NextTasks;
        previousTask.isActive = false;
    }
}
