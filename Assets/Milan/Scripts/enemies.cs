using UnityEngine;

public class enemies : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

