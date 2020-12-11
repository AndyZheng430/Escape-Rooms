using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NeutralAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask playerMask;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange, sightRange, alertRange;
    public bool playerInSightRange, alertSightRange;
    public Animator anims;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        alertSightRange = Physics.CheckSphere(transform.position, alertRange, playerMask);
        
        if(!playerInSightRange && !alertSightRange) 
        {
            Stay();
        }
        if(!playerInSightRange && alertSightRange) 
        {
            Idle();
        }
        if(playerInSightRange || walkPointSet) 
        {
            Run();
        }
    }

    void Idle()
    {
        agent.SetDestination(transform.position);
        // set animation to idle state
        anims.SetBool("stay", false);
        anims.SetBool("run", false);
    }

    void Stay()
    {
        agent.SetDestination(transform.position);
        // set animation to idle state
        anims.SetBool("stay", true);
        anims.SetBool("run", false);
    }

    void Run()
    {
        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            anims.SetBool("run", true);
            agent.speed = 15f;
            agent.SetDestination(walkPoint);
            // set animation to run state
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.x < 1 && distanceToWalkPoint.z < 1) 
        {
            walkPointSet = false;
        }

    }
    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        while (transform.position.x + randomX < 10 || transform.position.x + randomX > 240)
        {
            randomX = Random.Range(-walkPointRange, walkPointRange);
        }
        while (transform.position.z + randomZ < 10 || transform.position.z + randomZ > 240)
        {
            randomZ = Random.Range(-walkPointRange, walkPointRange);
        }
        walkPointSet = true;
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
}
