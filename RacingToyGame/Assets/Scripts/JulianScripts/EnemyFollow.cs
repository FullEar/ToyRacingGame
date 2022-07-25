using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public int enemyNumber;
    public NavMeshAgent navMeshAgent;
    public float incrementSpeed = 3;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }

    public void SpeedUp()
    {
        navMeshAgent.speed += incrementSpeed;
    }
}
