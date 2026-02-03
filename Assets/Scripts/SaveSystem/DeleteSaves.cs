using UnityEngine;
using UnityEngine.UI;

public class DeleteSaves : MonoBehaviour
{
    [SerializeField] private Button deleteButton;
    private void Start()
    {
        deleteButton.onClick.AddListener(DeleteAllSaves);
    }
    private void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All saves deleted.");
        Bank.Instance.Deposit(50000);
        Debug.Log("Granted 50,000 currency for testing.");
    }
}
