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

    public Action<TowerData, TowerItemUI> OnUpgradeRequested;
    public void Setup(TowerData towerData)
    {
        nameText.text = towerData.towerName;
        iconImage.sprite = towerData.icon;
        levelText.text = "Level " + towerData.level.ToString();

        levelImage.DOKill();
        float levelValue =Mathf.Clamp01(towerData.level / 10f); // Assuming max level is 10
        levelImage.DOFillAmount(levelValue, lerpSpeed);
        levelImage.DOColor(levelGradient.Evaluate(levelValue), lerpSpeed);

        costText.text = "Cost: " + towerData.startUpgradeCost.ToString("N0");

        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(() => OnUpgradeRequested?.Invoke(towerData, this));
    }
    public void Refresh(TowerData towerData)
    {
        Setup(towerData);
        // Jump effect on icon
        iconImage.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f);
        upgradeButton.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);
        // can be sound or visual effect to indicate successful upgrade
    }
}
