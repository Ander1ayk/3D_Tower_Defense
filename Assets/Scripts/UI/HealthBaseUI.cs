using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBaseUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Gradient healthGragient;
    [SerializeField] private GameObject deathPanel;
    private float lerpSpeed = 1f;
    private void OnEnable()
    {
        HealthBase.OnHealthChanged += UpdateHealthUI;
        HealthBase.OnBaseDestroyed += OnBaseDestroyed;
    }
    private void OnDisable()
    {
        HealthBase.OnHealthChanged -= UpdateHealthUI;
        HealthBase.OnBaseDestroyed -= OnBaseDestroyed;
    }
    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float targethealth = (float)currentHealth / maxHealth;
        healthBar.DOKill();
        healthBar.DOFillAmount(targethealth, lerpSpeed);
        healthBar.color = healthGragient.Evaluate(targethealth);
    }
    private void OnBaseDestroyed()
    {
        deathPanel.SetActive(true);
    }
}
