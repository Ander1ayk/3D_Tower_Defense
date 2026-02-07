using UnityEngine;
using System;
public class HealthBase : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private AudioClip gameOver;
    private int maxHealth = 3;
    private int currentHealth;

    private bool isDestroyed = false;

    public static Action<int, int> OnHealthChanged;
    public static Action OnBaseDestroyed;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            //Destroy base
            //GameOver
            AudioManager.Instance.PlaySFX(gameOver, false, 1f);
            OnBaseDestroyed?.Invoke();
            isDestroyed = true;
            Debug.Log("Base Destroyed! Game Over!");
        }
        else
        {
            AudioManager.Instance.PlaySFX(damageSFX, false, 1f);
        }
    }
    public bool IsDestroyed() => isDestroyed;
}
