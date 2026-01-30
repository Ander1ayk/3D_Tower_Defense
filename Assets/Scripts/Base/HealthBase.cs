using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HealthBase : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private Gradient healthGragient;
    private float lerpSpeed = 1f;

    private bool isDestroyed = false;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            //Destroy base
            //GameOver
            isDestroyed = true;
            Debug.Log("Base Destroyed! Game Over!");
        }
    }
    private void UpdateHealthBar()
    {
        float targethealth = (float)currentHealth / maxHealth;
        healthBar.DOKill();
        healthBar.DOFillAmount(targethealth, lerpSpeed);
        healthBar.color = healthGragient.Evaluate(targethealth);
    }
    public bool IsDestroyed() => isDestroyed;
}
