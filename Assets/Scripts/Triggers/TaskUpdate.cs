using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUpdate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TaskManager.taskManager.UpdateTask();
            Destroy(gameObject);
        }
    }
}
