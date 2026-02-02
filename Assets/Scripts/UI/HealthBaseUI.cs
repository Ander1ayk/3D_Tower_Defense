using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBaseUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Gradient healthGragient;
    private float lerpSpeed = 1f;
    private void OnEnable()
    {
        HealthBase.OnHealthChanged += UpdateHealthUI;
    }
    private void OnDisable()
    {
        HealthBase.OnHealthChanged -= UpdateHealthUI;
    }
    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float targethealth = (float)currentHealth / maxHealth;
        healthBar.DOKill();
        healthBar.DOFillAmount(targethealth, lerpSpeed);
        healthBar.color = healthGragient.Evaluate(targethealth);
    }
}
