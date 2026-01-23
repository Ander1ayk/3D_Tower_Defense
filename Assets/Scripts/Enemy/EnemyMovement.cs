using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Attributes")] 
    [SerializeField] private EnemyData enemyData;

    private Transform target;
    private int pathIndex = 0;
    private void Start()
    {
        target = LevelManager.main.pathPoints[pathIndex];
    }

    private void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.pathPoints.Length)
            {
                SpawnManager.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.pathPoints[pathIndex]; 
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 5f);
        rb.MoveRotation(smoothRotation);
        rb.MovePosition(transform.position + direction * enemyData.speed * Time.fixedDeltaTime); 
    }
}
