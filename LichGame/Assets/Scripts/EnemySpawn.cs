using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyList;
    private GameObject[] activeEnemyList;
    private int enemyIndex = 0;
    [SerializeField] private bool spawningActive;
    [SerializeField] private int stage;
    [SerializeField] private WaveManager waveManager;
    void Awake()
    {
        activeEnemyList = new GameObject[enemyList.Length];
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        waveManager.spawn = this;
    }
    public void startWave(int points, int groupSize, float timeBetweenWaves)
    {
        if (enemyIndex < enemyList.Length)
        {
            activeEnemyList[enemyIndex] = enemyList[enemyIndex];
            enemyIndex++;
        }
        StartCoroutine(spawnForRound(points, groupSize, timeBetweenWaves));
    }
    private void spawnEnemy(GameObject Enemy)
    {
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
    }
    IEnumerator spawnForRound(int points, int groupSize, float timeBetweenWaves)
    {
        int pointTotal = 0;

        bool isFifthWave = waveManager.currentWave == 5;

        while (pointTotal < points)
        {
            int spawnCount;

            if (isFifthWave)
            {
                spawnCount = 1;
            }
            else
            {
                spawnCount = groupSize;
            }

            for (int i = 0; i < spawnCount; i++)
            {
                GameObject nextEnemy;

                if (isFifthWave)
                {
                    nextEnemy = enemyList[4];
                }
                else
                {
                    nextEnemy = activeEnemyList[Random.Range(0, enemyIndex)];
                }

                if (nextEnemy != null)
                {
                    EnemyInformation enemyInformation = nextEnemy.GetComponent<EnemyInformation>();

                    if (enemyInformation != null)
                    {
                        spawnEnemy(nextEnemy);
                        pointTotal += enemyInformation.pointValue;
                    }
                }
            }

            yield return new WaitForSeconds(timeBetweenWaves);

            if (isFifthWave)
            {
                break;
            }
        }

        waveManager.spawnStarted = false;
    }
}
