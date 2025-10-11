using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private Rigidbody rb;

    [Header("Stats")]
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (agent != null)
        {
            agent.enabled = false;
        }

        if (deathParticles != null)
        {
            GameObject particlesInstance = Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(particlesInstance, 2f);
        }

        rb.isKinematic = false;
        rb.AddForce(new Vector3(Random.Range(-1f,1f),1,Random.Range(-1f,1f)) * 2f, ForceMode.Impulse);

        Destroy(gameObject, 2f);
    }
}
