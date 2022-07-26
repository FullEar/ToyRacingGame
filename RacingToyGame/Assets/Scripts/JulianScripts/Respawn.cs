using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform[] respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint[0].transform.position;
        }
        if (other.CompareTag("Enemy"))
        {
            int number = other.GetComponent<EnemyFollow>().enemyNumber;
            other.transform.position = respawnPoint[number].transform.position;
        }
    }
}
