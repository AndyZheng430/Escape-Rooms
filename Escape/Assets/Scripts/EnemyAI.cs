using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask playerMask;
    public float attackRange;
    public bool playerInAttackRange, trigger;
    public Animator anims;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        anims = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (trigger)
        {
            ChasePlayer();
        }
        if (!trigger) {
            Stop();
        }
        if (trigger && playerInAttackRange) 
        {
            AttackPlayer();
        }
    }

    private void Stop()
    {
        agent.SetDestination(transform.position);
        anims.speed = 0f;
    }

    private void ChasePlayer()
    {
        anims.speed = 1f;
        agent.SetDestination(player.position);
        anims.SetBool("Attack", false);
        anims.SetBool("Walk", true);
    }
    private void AttackPlayer()
    {
        anims.speed = 0.5f;
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        anims.SetBool("Walk", false);
        anims.SetBool("Attack", true);
    }
}
