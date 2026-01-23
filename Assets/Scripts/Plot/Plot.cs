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

    // Реализация интерфейса Enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material = hoverMat;
    }

    // Реализация интерфейса Exit
    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material = startMat;
    }

    // Реализация интерфейса Down (Исправлена опечатка)
    public void OnPointerDown(PointerEventData eventData)
    {
        if (tower != null) return;

        GameObject towerToBuild = BuildManager.Instance.GetSelectedTowerPrefab();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }
}
