using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Attributes")] 
    [SerializeField] private EnemyData enemyData;

    private Health health;

    private Transform target;
    private int pathIndex = 0;

    private float currentSpeed;
    private Coroutine slowCoroutine;
    private void Start()
    {
        health = GetComponent<Health>();
        currentSpeed = enemyData.speed;
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
        if(health.IsDestroyed()) return;
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 5f);
        rb.MoveRotation(smoothRotation);
        rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime); 
    }
    public void ApplySlow(float factor, float duration)
    {
        if(slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
        UpdateSpeed(factor);
        slowCoroutine = StartCoroutine(SlowDuration(duration));
    }
    private IEnumerator SlowDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        ResetSpeed();
        slowCoroutine = null;
    }
    private void UpdateSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
    private void ResetSpeed()
    {
        currentSpeed = enemyData.speed;
    }
}
