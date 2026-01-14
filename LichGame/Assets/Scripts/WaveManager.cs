using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemySpawn spawn;
    [SerializeField] private int points = 10;
    public bool spawnStarted = false;
    public int currentWave = 0;
    public int timeUntilNextWave;
    private int timeBetweenWavesSeconds = 60;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        StartCoroutine(TimeBetweenWaves());
    }

    public void StartNextWave()
    {
        currentWave += 1;
        spawn.startWave(points, 3, 4);
        points *= 2;
    }

    IEnumerator TimeBetweenWaves()
    {
        while (currentWave < 5)
        {
            StartNextWave();

            timeUntilNextWave = timeBetweenWavesSeconds;

            while (timeUntilNextWave > 0)
            {
                yield return new WaitForSeconds(1f);
                timeUntilNextWave--;
                text.text = "Time until next wave:" + timeUntilNextWave;
            }
        }
    }
}