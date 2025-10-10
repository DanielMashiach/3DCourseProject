using NUnit.Framework;
using UnityEditor.Search;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    [SerializeField] private int damage = 1;
    private bool canHit = false;
    public void EnableHit()
    {
        canHit = true;
    }

    public void DisableHit()
    {
        canHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canHit) return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Hit Enemy!");
        }
    }
}
