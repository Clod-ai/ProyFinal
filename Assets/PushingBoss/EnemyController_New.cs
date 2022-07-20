using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_NewBoss : MonoBehaviour
{

    public float lookRadius = 30f;

    Transform target;
    NavMeshAgent agent;
    public Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private int ataque = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            mNavMeshAgent.isStopped = false;
            mNavMeshAgent.destination = target.position;
            mAnimator.SetTrigger("Walk");

            if (distance <= agent.stoppingDistance)
            {
                //attack
                FaceTarget();
            }
            
        }else
        {
                mAnimator.SetTrigger("Stop");
                mNavMeshAgent.isStopped = true;
        }

        if(distance <= 3f)
        {
            mAnimator.SetTrigger("Melee");
            ataque++;
        }
        if(ataque != 0)
        {
            mAnimator.SetTrigger("MeleeOut");
            ataque = 0;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
