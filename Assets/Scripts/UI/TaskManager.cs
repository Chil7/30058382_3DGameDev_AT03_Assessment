using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private Task currTask;
    private Task previousTask;

    public static TaskManager taskManager { get; private set; }

    private void Start()
    { 
        if (taskManager == null)
        {
            taskManager = this;
        }

        if (currTask.gameObject.activeSelf == false)
        {
            currTask.gameObject.SetActive(true);
        }
    }

    public void UpdateTask()
    {
        previousTask = currTask;
        currTask = currTask.NextTasks;
        previousTask.gameObject.SetActive(false);
        currTask.gameObject.SetActive(true);
    }
}
