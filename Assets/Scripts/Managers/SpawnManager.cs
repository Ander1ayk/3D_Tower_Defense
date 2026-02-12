using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 2f;
    [SerializeField] private float timeBetweenWaves = 5.0f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps; // enemies per second
    private bool isSpawning = false;
    private float currentHealthMultiplier = 1f;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void OnDestroy()
    {
        onEnemyDestroy.RemoveListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if(enemiesLeftToSpawn == 0 && enemiesAlive == 0)
        {
            EndWave();
        }
    }
    private void SpawnEnemy()
    {
        int availableTypes = 1;

        if (currentWave >= 7)
        {
            availableTypes = 3;
        }
        else if (currentWave >= 4)
        {
            availableTypes = 2;
        }

        int maxIndex = Mathf.Min(availableTypes, enemyPrefabs.Length);

        GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, maxIndex)];
        GameObject enemy = Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);

        Health enemyHealth = enemy.GetComponent<Health>();
        if(enemyHealth != null)
        {
            enemyHealth.SetHealthMultiplier(currentHealthMultiplier);
        }
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        if(ScreenUI.Instance != null)

            ScreenUI.Instance.UpdateWaveInfo(currentWave);

        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = enemiesPerSecond;
    }
    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        if(currentWave %2 == 0)
        {
            currentHealthMultiplier *= 1.10f;
        }
        else
        {
            currentHealthMultiplier *= 1.05f;
        }
            StartCoroutine(StartWave());
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
