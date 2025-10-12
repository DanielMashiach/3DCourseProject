using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private PlayerHealth playerHealth;

    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    private NavMeshAgent agent;

    public float patrolRadius = 5f; 
    private Vector3 patrolTarget;
    private bool isPatrolling = true;
    private float patrolWaitTime = 2f;
    private float patrolTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();

        patrolTarget = transform.position;
    }

void Update()
{
    if (!agent.enabled) return;

    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    if (distanceToPlayer <= attackRange)
    {
        agent.isStopped = true;
        FaceTarget(player.position);

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            if (playerHealth != null)
                playerHealth.TakeDamage(1);
            Debug.Log("Enemy Attacks Player!");
        }
    }
    else if (distanceToPlayer <= patrolRadius * 2f)
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        FaceTarget(player.position);
    }
    else
    {
        Patrol();
    }
}

    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            if (playerHealth != null)
                playerHealth.TakeDamage(1);
            Debug.Log("Enemy Attacks Player!");
        }
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolTarget) < 0.5f || patrolTimer <= 0f)
        {
            patrolTarget = transform.position + new Vector3(Random.Range(-patrolRadius, patrolRadius), 0,
                                                            Random.Range(-patrolRadius, patrolRadius));
            agent.SetDestination(patrolTarget);
            patrolTimer = patrolWaitTime;
        }
        else
        {
            patrolTimer -= Time.deltaTime;
        }

        FaceTarget(patrolTarget);
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}