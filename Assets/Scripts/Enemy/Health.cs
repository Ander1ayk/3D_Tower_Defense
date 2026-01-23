using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private EnemyData enemyData;
    private float currentHealth;
    private void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, enemyData.maxHealth);
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
