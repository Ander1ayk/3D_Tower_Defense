using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [Header("Attributes")]
    [SerializeField] private TowerData towerData;

    private Transform target;
    private float timeUntilFire;
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
        else
        {
            timeUntilFire += Time.deltaTime;
            
            if(timeUntilFire >= 1f / towerData.bulletsPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }
    private void Shoot()

    {
        Vector3 direction = target.position - firePoint.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation *= Quaternion.Euler(90f, 0f, 0f); 

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation );
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetTarget(target);

    }
    private void FindTarget()
    {
        RaycastHit[] hits = Physics.SphereCastAll(towerRotationPoint.position, towerData.targetingRange, 
            transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetIsInRange()
    {
        return Vector3.Distance(target.position, transform.position) <= towerData.targetingRange;
    }
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.z - towerRotationPoint.position.z, target.position.x
            - towerRotationPoint.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        towerRotationPoint.rotation = Quaternion.RotateTowards(towerRotationPoint.rotation,
            targetRotation, towerData.rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(towerRotationPoint.position, towerData.targetingRange);
    }
}
