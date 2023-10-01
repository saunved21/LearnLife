using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemy_AI : MonoBehaviour
{
    public Transform target;
    public float chaserange=5f;
    public float turnSpeed=5f;
    
    NavMeshAgent navMeshAgent;
    float distancetoTarget = Mathf.Infinity;
    bool provoked; 

    enemy_health health;

    player_health health1;
 



    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<enemy_health>();
        health1 = GetComponent<player_health>();
        

    }


    void Update()
    {
        if (health.IsDead())
        {
            enabled=false;
            navMeshAgent.enabled=false;
        }
        distancetoTarget = Vector3.Distance(target.position, transform.position);   //us and player distance
        if(provoked)
        {
            engage_Target();
        }
        else if (chaserange>=distancetoTarget)
        {
            provoked = true;
            
        }
    }

    void engage_Target()
    {
        face_target();
        if(distancetoTarget>= navMeshAgent.stoppingDistance)
        {
            chase_target();
        }

        if(distancetoTarget<=navMeshAgent.stoppingDistance)
        {
            attack_target();
        }
    }

    void chase_target()
    {
        GetComponent<Animator>().SetBool("attack_bool",false);
        navMeshAgent.SetDestination(target.position); 
        GetComponent<Animator>().SetTrigger("move_trig");
    }

    void attack_target()
    {
        GetComponent<Animator>().SetBool("attack_bool",true);

    }

    void face_target()
    {
       Vector3 direction = (target.position - transform.position).normalized;
       Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
       transform.rotation= Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime* turnSpeed);
    }

    void Ondamage()
    {
        provoked=true;   
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaserange);
    }
}
