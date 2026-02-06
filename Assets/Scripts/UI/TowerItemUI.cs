using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class TowerItemUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Image iconImage; 
    public TextMeshProUGUI levelText;
    public Image levelImage;
    public TextMeshProUGUI costText;
    public Button upgradeButton;

    public Gradient levelGradient;
    private float lerpSpeed = 1f;

    public Action<TowerUpgradeState, TowerItemUI> OnUpgradeRequested;
    public void Setup(TowerUpgradeState state)
    {
        nameText.text = state.data.towerName;
        iconImage.sprite = state.data.icon;
        levelText.text = "Level " + state.currentLevel.ToString();

        levelImage.DOKill();
        float levelValue =Mathf.Clamp01(state.currentLevel / 10f); // Assuming max level is 10
        levelImage.DOFillAmount(levelValue, lerpSpeed);
        levelImage.DOColor(levelGradient.Evaluate(levelValue), lerpSpeed);

        costText.text = "Cost: " + state.nextUpgradeCost.ToString("N0");

        if (state.currentLevel >= 10)
        {
            costText.text = "Max Level";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }
            upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(() => OnUpgradeRequested?.Invoke(state, this));
    }
    public void Refresh(TowerUpgradeState state)
    {
        Setup(state);
        // Jump effect on icon
        iconImage.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f);
        upgradeButton.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);
        // can be sound or visual effect to indicate successful upgrade
    }
}
