using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        agent = GetComponent<NavMeshAgent>();
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Keep only horizontal direction
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
        else
        {
            agent.isStopped = true;
            Attack();
        }
    }

    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            Debug.Log("Enemy Attacks!");
        }
    }
}
