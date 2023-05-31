using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUpdateArea : MonoBehaviour
{
    [SerializeField] private Area newArea;
    private GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        enemy = GameObject.FindWithTag("Enemy");
        Enemy _enemy = enemy.GetComponent<Enemy>();

        if (other.tag == "Player")
        {
            _enemy.currArea = newArea;
            _enemy.StateMachine.SetState(new Enemy.PatrolState(_enemy));
            gameObject.SetActive(false);
        }
    }
}
