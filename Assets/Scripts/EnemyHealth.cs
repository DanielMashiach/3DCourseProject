using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 3;
    private int currentHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }
}
