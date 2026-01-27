using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private EnemyData enemyData;
    private float currentHealth;
    private bool isDestroyed = false; 
    private void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, enemyData.maxHealth);
        if (currentHealth <= 0f && !isDestroyed)
        {
            Die();
        }
    }
    private void Die()
    {
        SpawnManager.onEnemyDestroy.Invoke();
        LevelManager.main.IncreaseCurrency(enemyData.rewardMatchCoins);
        isDestroyed = true;
        Destroy(gameObject);
    } 
}
