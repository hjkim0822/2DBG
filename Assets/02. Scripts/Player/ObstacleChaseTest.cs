using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleChaseTest : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;

    public float attackRadius = 2;
    public float chaseRadius = 10;
    public float lookRadius = 15;

    public bool isFound = false;

    public State state = State.Patrol;

    public enum State { 
        Patrol,
        Idle, 
        Chase, 
        Attack
    }

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        agent.stoppingDistance = attackRadius;          //Set stopping distance; where the agent will stop

        StartCoroutine(CheckState());
        StartCoroutine(ObstacleAction());
    }


    //Search for Player while patrolling
    private void FixedUpdate()
    {
        int layer = 1 << LayerMask.NameToLayer("Player");
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, lookRadius, layer);

        if (cols.Length > 0){               //if player collides with lookradius, isFound
            target = cols[0].gameObject;
            isFound = true;
        }
        else { 
            target = null;
            isFound = false;
            
            state = State.Patrol;           //if !isFound, keep patrol
        }
    }


    IEnumerator CheckState() {
        while (isFound) {

            yield return new WaitForSeconds(0.3f);

            float distance = Vector2.Distance(target.transform.position, transform.position);

            if (distance <= attackRadius){  //in attack radius
                state = State.Attack;
            }
            else if (distance <= chaseRadius){  //inside chase radius
                state = State.Chase;
            }
            else if (distance <= lookRadius) {  //inside look radius
                state = State.Idle;
            }   
        }
    }


    IEnumerator ObstacleAction()
    {
        switch (state) {
            case State.Patrol:
                agent.isStopped = false;
                //patrol
                break;
            case State.Idle:
                agent.isStopped = true;
                break;
            case State.Chase:
                agent.isStopped = false;
                agent.SetDestination(target.transform.position);
                break;
            case State.Attack:
                agent.isStopped = true;
                //attack
                break;
        }

        yield return new WaitForSeconds(0.3f);

    }

    private void OnDrawGizmos()
    {
        if (state == State.Chase) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
        }
        if (state == State.Attack) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
        if (state == State.Patrol) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }
    }

}
