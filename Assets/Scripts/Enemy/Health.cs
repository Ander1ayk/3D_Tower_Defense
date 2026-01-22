using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float maxHealth = 2f;
    private float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        SpawnManager.onEnemyDestroy.Invoke();
        Destroy(gameObject);
    } 
}
