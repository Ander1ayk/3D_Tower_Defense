using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 200f;

    private Transform target;
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();
       if(!CheckTargetIsInRange())
        {
            target = null;
        }
    }
    private void FindTarget()
    {
        RaycastHit[] hits = Physics.SphereCastAll(towerRotationPoint.position, targetingRange, transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetIsInRange()
    {
        return Vector3.Distance(target.position, transform.position) <= targetingRange;
    }
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.z - towerRotationPoint.position.z, target.position.x
            - towerRotationPoint.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        towerRotationPoint.rotation = Quaternion.RotateTowards(towerRotationPoint.rotation,
            targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(towerRotationPoint.position, targetingRange);
        //Handles.color = Color.cyan;
        //Handles.DrawWireDisc(towerRotationPoint.position, Vector3.up, targetingRange);
    }
}
