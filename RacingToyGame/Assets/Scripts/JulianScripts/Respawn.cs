using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform[] respawnPoint;
    [SerializeField] private bool canPlayerTeleport = false;
    [SerializeField] private bool canEnemyTeleport = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canPlayerTeleport)
        {
            other.transform.position = respawnPoint[0].transform.position;
        }
        if (other.CompareTag("Enemy") && canEnemyTeleport) 
        {
            int number = other.GetComponent<EnemyFollow>().enemyNumber;
            other.transform.position = respawnPoint[number].transform.position;
        }
    }
}
