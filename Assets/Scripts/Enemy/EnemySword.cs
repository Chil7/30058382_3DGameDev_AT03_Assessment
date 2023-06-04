using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    private GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        //If the sword hits the player, it is game over
        enemy = GameObject.FindWithTag("Enemy");
        Enemy _enemy = enemy.GetComponent<Enemy>();

        if (other.tag == "Player")
        {
            _enemy.GameOver();
        }
    }
}
