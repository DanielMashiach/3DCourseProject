using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private bool canHit = false;
    private bool hasHit = false;

    public void EnableHit()
    {
        canHit = true;
        hasHit = false;
    }

    public void DisableHit()
    {
        canHit = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!canHit || hasHit) return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            hasHit = true;
        }
    }
}