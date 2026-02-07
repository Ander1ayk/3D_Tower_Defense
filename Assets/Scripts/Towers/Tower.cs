using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Transform towerRotationPoint;
    [SerializeField] protected LayerMask enemyMask;
    [Header("Attributes")]
    [SerializeField] protected TowerData towerData;
    [SerializeField] protected AudioClip fireSFX;


    protected Transform target;
    protected float timeUntilFire;

    protected int currentLevel;

    protected virtual void Awake()
    {
        var savedTower = JsonSave.Instance.currentData.towerLevels.Find(e => e.towerName == towerData.towerName);
        if(savedTower != null)
        {
            currentLevel = savedTower.level;
        }
        else
        {
            currentLevel = 1;
        }
    }
    
    protected virtual void FindTarget()
    {
        RaycastHit[] hits = Physics.SphereCastAll(towerRotationPoint.position, towerData.targetingRange, 
            transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    protected bool CheckTargetIsInRange()
    {
        if (target == null) return false;
        return Vector3.Distance(target.position, transform.position) <= towerData.targetingRange;
    }
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, towerData.targetingRange);
    }
}
