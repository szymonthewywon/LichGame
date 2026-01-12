using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyList;
    private GameObject[] activeEnemyList;
    [SerializeField] private bool spawningActive;
    [SerializeField] private int stage;
    [SerializeField] private WaveManager waveManager;

    void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        waveManager.spawn = this;
    }

    public void startWave(int points, int groupSize, float timeBetweenWaves)
    {
        activeEnemyList = enemyList;
        StartCoroutine(spawnForRound(points, groupSize, timeBetweenWaves));
    }
    private void spawnEnemy(GameObject Enemy)
    {
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-2.5f,2.5f), Random.Range(-2.5f, 2.5f),0), Quaternion.identity);
    }
    IEnumerator spawnForRound(int points, int groupSize, float timeBetweenWaves)
    {
        int pointTotal = 0;
        while (pointTotal < points)
        {
            for (int i = 0; i < groupSize; i++)
            {
                GameObject nextEnemy = activeEnemyList[Random.Range(0, activeEnemyList.Length)];
                EnemyInformation enemyInformation = nextEnemy.GetComponent<EnemyInformation>();
                spawnEnemy(nextEnemy);
                pointTotal += enemyInformation.pointValue;
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
