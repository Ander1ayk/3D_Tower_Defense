using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("References")]
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material hoverMat;

    private GameObject tower;
    private Material startMat;
    private void Start()
    {
        startMat = meshRenderer.material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material = hoverMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material = startMat;
    }
    public void OnPointerDown(PointerEventData eventData)
    {  
        if (tower != null) return;

        TowerData towerToBuild = BuildManager.Instance.GetSelectedTowerPrefab();
        if(towerToBuild.costInMatch > Wallet.Instance.GetCurrency())
        {
            Debug.Log("Not enough currency to build this tower!");
            return;
        }
        Wallet.Instance.SpendCurrency(towerToBuild.costInMatch); 
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
