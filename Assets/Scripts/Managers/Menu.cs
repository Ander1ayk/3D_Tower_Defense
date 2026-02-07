using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI currencyUI;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip buttonClickSFX;
    private bool isMenuOpen = true;
    public void ToggleMenu()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX, false, 0.9f);
        isMenuOpen = !isMenuOpen; 
        anim.SetBool("MenuOpen", isMenuOpen);
    }
    private void OnGUI()
    {
        currencyUI.text = "Currency: " + Wallet.Instance.GetCurrency();
    }
}
